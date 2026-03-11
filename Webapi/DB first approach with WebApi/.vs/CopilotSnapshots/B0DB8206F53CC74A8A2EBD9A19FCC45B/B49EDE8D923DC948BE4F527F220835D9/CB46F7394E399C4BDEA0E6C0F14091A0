using DB_first_approach_with_WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DB_first_approach_with_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly CollegeDb1Context _context;

        public StudentController(CollegeDb1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students.Select(s => new
            {
                s.Id,
                s.Name,
                s.M1,
                s.M2,
                Total = (s.M1 ?? 0) + (s.M2 ?? 0),
                Grade = CalculateGrade((s.M1 ?? 0) + (s.M2 ?? 0))
            }).ToList();

            return Ok(students);
        }

        private static string CalculateGrade(int total)
        {
            if (total >= 90) return "A";
            if (total >= 80) return "B";
            if (total >= 70) return "C";
            if (total >= 60) return "D";
            return "F";
        }
    }
}

