using Microsoft.AspNetCore.Mvc;

namespace sumofthreenumbers.Controllers
{
    public class AddingThreeNumbers : Controller
    {
        public IActionResult Addition(int a, int b, int c)
        {
            int result = a + b + c;
            return Content(result.ToString());
        }
    }
}
