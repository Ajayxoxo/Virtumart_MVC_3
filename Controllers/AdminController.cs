using Microsoft.AspNetCore.Mvc;

namespace Virtumart_MVC_3.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }
    }
}
