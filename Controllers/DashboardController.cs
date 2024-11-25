using Microsoft.AspNetCore.Mvc;

namespace Virtumart_MVC_3.Controllers
{
    public class DashboardController : Controller
    {

        private bool IsUser()
        {
            var user = HttpContext.Session.GetString("role");
            return user == "user";
        }
        public IActionResult User()
        {
            if (!IsUser())
            { 
                return RedirectToAction( "Signin", "Signin");
            }
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }
    }
}
