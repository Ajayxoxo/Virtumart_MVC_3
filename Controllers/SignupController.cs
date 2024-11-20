using Microsoft.AspNetCore.Mvc;
using Virtumart_MVC_3.Models;

namespace Virtumart_MVC_3.Controllers
{
    public class SignupController : Controller
    {
        private readonly VirtuMartContext _context;

        public SignupController(VirtuMartContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.userinfo.FirstOrDefault(u => u.Username == user.Username);
                if (existingUser != null)
                {

                    ViewBag.Message = "Username already exists. Please choose a different one.";
                    return View();
                }
                try
                {
                    _context.userinfo.Add(user);
                    _context.SaveChanges();
                    ViewBag.Message = "Sucessfully Added";
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error While Interacting with the Database";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "An Error Occoured";
                return View();
            }
        }
    }
}
