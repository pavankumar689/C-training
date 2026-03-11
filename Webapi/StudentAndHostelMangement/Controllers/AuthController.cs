using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentAndHostelMangement.DTO;
using StudentAndHostelMangement.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly CollegeDb1Context _context;

    public AuthController(IConfiguration config, CollegeDb1Context context)
    {
        _config = config;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDTO login)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.Username == login.Username &&
                                 u.Password == login.Password);

        if (user == null)
            return Unauthorized("Invalid username or password");

        var token = GenerateToken(user.Username);

        return Ok(new { token });
    }

    private string GenerateToken(string username)
    {
        var jwtSettings = _config.GetSection("Jwt");

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["Key"])
        );

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}