using Microsoft.AspNetCore.Mvc;
using Virtumart_MVC_3.Models;

namespace Virtumart_MVC_3.Controllers
{
    public class ProductController : Controller
    {
        private readonly VirtuMartContext _context;

        private bool IsAdmin()
        {
            var role = HttpContext.Session.GetString("role");
            return role == "admin";
        }

        public ProductController(VirtuMartContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!(IsAdmin()))
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            var products = _context.productinfo.ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            if (!(IsAdmin()))
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!(IsAdmin()))
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            try
            {
                product.updatedAt = DateTime.Now;
                _context.productinfo.Add(product);
                _context.SaveChanges();
                ViewBag.Message = "Successfully Added";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = "An Error Occured";
                return View();
            }
        }

        public IActionResult Update(int id)
        {
            if (!(IsAdmin()))
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            var product = _context.productinfo.FirstOrDefault(p => p.productid == id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (!(IsAdmin()))
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Invalid product data.";
                return View(product);
            }

            var existingProduct = _context.productinfo.FirstOrDefault(p => p.productid == product.productid);
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            existingProduct.productname = product.productname;
            existingProduct.productdes = product.productdes;
            existingProduct.quantity = product.quantity;
            existingProduct.price = product.price;
            existingProduct.discount = product.discount;
            existingProduct.updatedAt = DateTime.Now;  //

            // Save changes to the database
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Product updated successfully.";
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            try
            {
                if (!(IsAdmin()))
                {
                    return RedirectToAction("AccessDenied", "Home");
                }
                var product = _context.productinfo.FirstOrDefault(_ => _.productid == id);
                if (product == null)
                {
                    ViewBag.Message = "Product Not Found";
                }
                return View(product);

            }
            catch (Exception ex)
            {
                ViewBag.Message = "An Error Occoured" + ex;
                return View();
            }
        }
        [HttpPost]
        public IActionResult Remove(Product product)
        {
            if (!(IsAdmin()))
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            _context.productinfo.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
