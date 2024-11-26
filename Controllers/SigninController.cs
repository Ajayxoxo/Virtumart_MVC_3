using Microsoft.AspNetCore.Mvc;
using Virtumart_MVC_3.Models;

namespace Virtumart_MVC_3.Controllers
{
    public class SigninController : Controller
    {
        private readonly VirtuMartContext _context;

        public SigninController(VirtuMartContext context)
        {
            _context = context;
        }
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(SigninModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.userinfo.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password );
                if (user == null)
                {
                    ViewBag.Message = "Invalid Username or Password";
                    return View();
                }
                else 
                {
                    HttpContext.Session.SetString("role","user");
                    return RedirectToAction("Index","Home");
                }
            }
            ViewBag.Message = "Please fill all required fields";
            return View();
        }
    }
}
