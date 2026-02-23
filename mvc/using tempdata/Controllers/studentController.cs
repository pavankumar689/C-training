using Microsoft.AspNetCore.Mvc;

namespace using_tempdata.Controllers
{
    public class studentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Receive()
        {
            int result = (int)TempData["number"] * (int)TempData["number"];
            return Content($"Result: {result}");
        }
    }
}
