using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;
using EmployeeApp.Models;
namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var connString = _configuration.GetConnectionString("DefaultConnection");
            await using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            var employees = new System.Collections.Generic.List<Employee>();
            const string ensureColumnSql = "IF COL_LENGTH('Employees', 'Photo') IS NULL ALTER TABLE Employees ADD Photo VARBINARY(MAX) NULL";
            await using var ensureCmd = new SqlCommand(ensureColumnSql, conn);
            await ensureCmd.ExecuteNonQueryAsync();

            const string sql = "SELECT Id, Name, Aadhaar, Address, DateOfBirth, JoiningDate, Salary, Photo FROM Employees";
            await using var cmd = new SqlCommand(sql, conn);
            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                employees.Add(new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Aadhaar = reader.GetString(2),
                    Address = reader.GetString(3),
                    DateOfBirth = reader.GetDateTime(4),
                    JoiningDate = reader.GetDateTime(5),
                    Salary = reader.GetDecimal(6),
                    Photo = reader.IsDBNull(7) ? null : (byte[])reader.GetValue(7)
                });
            }
            return View(employees);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var connString = _configuration.GetConnectionString("DefaultConnection");
            await using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            const string sql = "SELECT Id, Name, Aadhaar, Address, DateOfBirth, JoiningDate, Salary, Photo FROM Employees WHERE Id = @Id";
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

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
                return View(employee);
            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var connString = _configuration.GetConnectionString("DefaultConnection");
            await using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            const string sql = "SELECT Id, Name, Aadhaar, Address, DateOfBirth, JoiningDate, Salary, Photo FROM Employees WHERE Id = @Id";
            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);

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
                return View(employee);
            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee, IFormFile? uploadPhoto)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            var connString = _configuration.GetConnectionString("DefaultConnection");
            await using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            // Check Aadhaar conflict
            const string checkSql = "SELECT COUNT(1) FROM Employees WHERE Aadhaar = @Aadhaar AND Id != @Id";
            await using var checkCmd = new SqlCommand(checkSql, conn);
            checkCmd.Parameters.AddWithValue("@Aadhaar", employee.Aadhaar ?? (object)System.DBNull.Value);
            checkCmd.Parameters.AddWithValue("@Id", id);
            
            if ((int)await checkCmd.ExecuteScalarAsync() > 0)
            {
                ModelState.AddModelError("Aadhaar", "Another employee with this Aadhaar number already exists.");
                return View(employee);
            }

            if (uploadPhoto != null && uploadPhoto.Length > 0)
            {
                using var ms = new MemoryStream();
                await uploadPhoto.CopyToAsync(ms);
                employee.Photo = ms.ToArray();
            }

            string sql;
            if (employee.Photo != null)
            {
                sql = @"UPDATE Employees
                    SET Name = @Name, Aadhaar = @Aadhaar, Address = @Address, 
                        DateOfBirth = @DateOfBirth, JoiningDate = @JoiningDate, Salary = @Salary, Photo = @Photo
                    WHERE Id = @Id";
            }
            else
            {
                sql = @"UPDATE Employees
                    SET Name = @Name, Aadhaar = @Aadhaar, Address = @Address, 
                        DateOfBirth = @DateOfBirth, JoiningDate = @JoiningDate, Salary = @Salary
                    WHERE Id = @Id";
            }

            await using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", employee.Name ?? (object)System.DBNull.Value);
            cmd.Parameters.AddWithValue("@Aadhaar", employee.Aadhaar ?? (object)System.DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", employee.Address ?? (object)System.DBNull.Value);
            cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            
            if (employee.Photo != null)
            {
                cmd.Parameters.AddWithValue("@Photo", employee.Photo);
            }

            await cmd.ExecuteNonQueryAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee, IFormFile? uploadPhoto)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            var connString = _configuration.GetConnectionString("DefaultConnection");

            await using var conn = new SqlConnection(connString);
            await conn.OpenAsync();

            // Check if Aadhaar number already exists
            const string checkSql = "SELECT COUNT(1) FROM Employees WHERE Aadhaar = @Aadhaar";
            await using var checkCmd = new SqlCommand(checkSql, conn);
            checkCmd.Parameters.AddWithValue("@Aadhaar", employee.Aadhaar ?? (object)DBNull.Value);
            
            var exists = (int)await checkCmd.ExecuteScalarAsync() > 0;
            if (exists)
            {
                ModelState.AddModelError("Aadhaar", "An employee with this Aadhaar number is already registered.");
                return View(employee);
            }

            // Add logic for storing photo
            if (uploadPhoto != null && uploadPhoto.Length > 0)
            {
                using var ms = new MemoryStream();
                await uploadPhoto.CopyToAsync(ms);
                employee.Photo = ms.ToArray();
            }

            const string ensureColumnSql = "IF COL_LENGTH('Employees', 'Photo') IS NULL ALTER TABLE Employees ADD Photo VARBINARY(MAX) NULL";
            await using var ensureCmd = new SqlCommand(ensureColumnSql, conn);
            await ensureCmd.ExecuteNonQueryAsync();

            const string sql = @"INSERT INTO Employees
                (Name, Aadhaar, Address, DateOfBirth, JoiningDate, Salary, Photo)
                VALUES (@Name, @Aadhaar, @Address, @DateOfBirth, @JoiningDate, @Salary, @Photo);";

            await using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Name", employee.Name ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Aadhaar", employee.Aadhaar ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", employee.Address ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            var photoParam = new SqlParameter("@Photo", System.Data.SqlDbType.VarBinary, -1);
            photoParam.Value = employee.Photo ?? (object)DBNull.Value;
            cmd.Parameters.Add(photoParam);

            await cmd.ExecuteNonQueryAsync();

            return RedirectToAction(nameof(Success));
        }

        public IActionResult Success() => View();
    }
}
