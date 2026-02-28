using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EmployeeApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var connString = _configuration.GetConnectionString("DefaultConnection");
            await using var conn = new SqlConnection(connString);
            
            try 
            {
                await conn.OpenAsync();

                // Make sure table exists
                string initTableSql = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                    BEGIN
                        CREATE TABLE Users (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            Username NVARCHAR(50) NOT NULL,
                            Password NVARCHAR(100) NOT NULL,
                            Role NVARCHAR(20) NOT NULL
                        );
                    END
                ";
                await using var initCmd = new SqlCommand(initTableSql, conn);
                await initCmd.ExecuteNonQueryAsync();
                
                // Check if user already exists
                const string checkSql = "SELECT COUNT(1) FROM Users WHERE Username = @Username";
                await using var checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@Username", model.Username);
                var exists = (int)await checkCmd.ExecuteScalarAsync() > 0;
                if (exists)
                {
                    ModelState.AddModelError("Username", "Username is already taken.");
                    return View(model);
                }

                // Insert User
                const string insertSql = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                await using var insertCmd = new SqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@Username", model.Username);
                insertCmd.Parameters.AddWithValue("@Password", model.Password); // Consider hashing in production!
                insertCmd.Parameters.AddWithValue("@Role", model.Role);
                await insertCmd.ExecuteNonQueryAsync();

                return RedirectToAction("Login", "Account");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Database error: " + ex.Message);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var connString = _configuration.GetConnectionString("DefaultConnection");
            await using var conn = new SqlConnection(connString);
            
            try 
            {
                await conn.OpenAsync();
                
                // Initialize Users table if it doesn't exist for demonstration purposes
                string initTableSql = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                    BEGIN
                        CREATE TABLE Users (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            Username NVARCHAR(50) NOT NULL,
                            Password NVARCHAR(100) NOT NULL,
                            Role NVARCHAR(20) NOT NULL
                        );
                        
                        -- Insert default admin
                        INSERT INTO Users (Username, Password, Role) VALUES ('admin', 'admin123', 'Admin');

                        -- Insert default user
                        INSERT INTO Users (Username, Password, Role) VALUES ('user', 'user123', 'User');
                    END
                ";
                await using var initCmd = new SqlCommand(initTableSql, conn);
                await initCmd.ExecuteNonQueryAsync();

                // Validate User
                const string sql = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password AND Role = @Role";
                await using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Username", model.Username);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                cmd.Parameters.AddWithValue("@Role", model.Role);

                var count = (int)await cmd.ExecuteScalarAsync();
                if (count > 0)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim(ClaimTypes.Role, model.Role)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username, password, or role.");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Database error: " + ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
