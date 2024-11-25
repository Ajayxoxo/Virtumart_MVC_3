using Microsoft.AspNetCore.Mvc;

namespace Virtumart_MVC_3.Controllers
{
    
    public class Account : Controller
    {
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Signin", "Signin");
        }
    }
}
