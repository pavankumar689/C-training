using Microsoft.AspNetCore.Mvc;
using StudentDTO.DTO;
using StudentDTO.Models;

namespace StudentDTO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();
        [HttpPost]
        public IActionResult CreateStudent(createRequestDTo request)
        {
            Student student = new Student
            {
                Id = students.Count + 1,
                Name = request.Name,
                Age = request.Age,
            };

            students.Add(student);

            return Ok(student.Id);
        }
        [HttpPut]
        public IActionResult UpdateStudent(UpdateRequestDTO request)
        {
            Student s = students.FirstOrDefault(s => s.Id == request.Id);
            if (s == null)
                return NotFound();
            s.m1 = request.m1;
            s.m2 = request.m2;
            return Ok(s.Id);
        }
        [HttpGet]
        public IActionResult GetResult(int id)
        {
            Student s = students.FirstOrDefault(s => s.Id == id);
            if (s == null)
                return NotFound();

            int total = s.m1 + s.m2;
            string grade;

            if (total >= 80)
                grade = "A";
            else if (total >= 60)
                grade = "B";
            else if (total >= 40)
                grade = "C";
            else
                grade = "F";

            GetResultDTO result = new GetResultDTO
            {
                Id = s.Id,
                Name = s.Name,
                m1 = s.m1,
                m2 = s.m2,
                Total = total,
                Grade = grade
            };

            return Ok(result);
        }

    }
}
