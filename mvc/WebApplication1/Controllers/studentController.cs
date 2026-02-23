using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class studentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Studentdata(int m1,int m2,int m3)
        {
            int result = m1 + m2 + m3;
            return View(result);
        }
    }
}
