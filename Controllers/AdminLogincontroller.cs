using Microsoft.AspNetCore.Mvc;
using Virtumart_MVC_3.Models;

namespace Virtumart_MVC_3.Controllers
{
    public class AdminLogincontroller : Controller
    {
        private readonly VirtuMartContext _context;

        public AdminLogincontroller(VirtuMartContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin admin)
        {
            var Admin = _context.admininfo.FirstOrDefault(u => u.Username == admin.Username && u.Password == admin.Password);
            if (Admin != null)
            {
                ViewBag.Message = "Login Sucessful Redirecting.....";
                return RedirectToAction("Index", "Product");
            }

            ViewBag.Message = "Invaild Username or Password";
            return View();
        }
    }
}
