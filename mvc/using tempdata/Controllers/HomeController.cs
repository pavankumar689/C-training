using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using using_tempdata.Models;

namespace using_tempdata.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult send(int a)
        {
            TempData["Number"] = a;
            return RedirectToAction("Receive", "student");
        }

        public IActionResult Index()
        {
            ViewData["Name"] = "Pavan";
            ViewData["CollegeName"] = "Lpu";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
