using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using EmployeeApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EmployeeApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // 1. Privacy-Safe Colleague Directory
        public async Task<IActionResult> Directory(string searchString, int page = 1)
        {
            var connString = _configuration.GetConnectionString("DefaultConnection");
            await using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            int pageSize = 12;
            int offset = (page - 1) * pageSize;

            var employees = new List<Employee>();

            string countSql = "SELECT COUNT(1) FROM Employees";
            if (!string.IsNullOrEmpty(searchString)) countSql += " WHERE Name LIKE @Search";
            await using var countCmd = new SqlCommand(countSql, conn);
            if (!string.IsNullOrEmpty(searchString)) countCmd.Parameters.AddWithValue("@Search", $"%{searchString}%");
            int totalItems = (int)await countCmd.ExecuteScalarAsync();

            // ONLY fetch non-sensitive data (Id, Name, JoiningDate, Photo)
            string sql = "SELECT Id, Name, JoiningDate, Photo FROM Employees";
            if (!string.IsNullOrEmpty(searchString)) sql += " WHERE Name LIKE @Search";
            sql += " ORDER BY Name ASC OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            await using var cmd = new SqlCommand(sql, conn);
            if (!string.IsNullOrEmpty(searchString)) cmd.Parameters.AddWithValue("@Search", $"%{searchString}%");
            cmd.Parameters.AddWithValue("@Offset", offset);
            cmd.Parameters.AddWithValue("@PageSize", pageSize);

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                employees.Add(new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    JoiningDate = reader.GetDateTime(2),
                    Photo = reader.IsDBNull(3) ? null : (byte[])reader.GetValue(3)
                });
            }

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            ViewBag.SearchString = searchString;

            return View(employees);
        }

        // 2. Digital Employee Handbook
        public IActionResult Handbook()
        {
            return View();
        }

        // 4. Find My ID Card
        [HttpGet]
        public IActionResult FindId()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FindId(int employeeId)
        {
            var connString = _configuration.GetConnectionString("DefaultConnection");
            await using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            const string sql = "SELECT Id, Name, Aadhaar, Address, DateOfBirth, JoiningDate, Salary, Photo FROM Employees WHERE Id = @Id";
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", employeeId);

            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var employee = new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Aadhaar = reader.GetString(2),
                    Address = reader.GetString(3),
                    DateOfBirth = reader.GetDateTime(4),
                    JoiningDate = reader.GetDateTime(5),
                    Salary = reader.GetDecimal(6),
                    Photo = reader.IsDBNull(7) ? null : (byte[])reader.GetValue(7)
                };
                return View("IdCard", employee);
            }

            TempData["ErrorMessage"] = "Could not find an employee with that ID number.";
            return RedirectToAction(nameof(FindId));
        }
    }
}
