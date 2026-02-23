using Microsoft.AspNetCore.Mvc;
using question.Data;

namespace question.Controllers
{
    public class studentController : Controller
    {
        private readonly studentrepository _repo;

        public studentController(studentrepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var students = _repo.GetAllStudents();
            return View(students);
        }
        
    }
}
