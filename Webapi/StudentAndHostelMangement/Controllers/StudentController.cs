using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAndHostelMangement.DTO;
using StudentAndHostelMangement.Services;

namespace StudentAndHostelMangement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent(CreateStudent dto)
        {
            var result = await _service.CreateStudent(dto);
            return Ok(result);
        }

        [HttpPost("assign-room")]
        public async Task<IActionResult> AssignRoom(AssignRoom dto)
        {
            await _service.AssignRoom(dto);
            return Ok("Room Assigned");
        }

        [HttpPut("change-room")]
        public async Task<IActionResult> ChangeRoom(ChangeRoom dto)
        {
            await _service.ChangeRoom(dto);
            return Ok("Room Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _service.DeleteStudent(id);

            if (!result)
                return NotFound();

            return Ok("Student Deleted");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateStudent(UpdateStudent dto)
        {
            var student = await _service.UpdateStudent(dto);

            return Ok(student);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _service.GetStudent(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _service.GetAllStudents();

            return Ok(students);
        }
    }
}
