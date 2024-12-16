using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Virtumart_MVC_3.Models;
using VirtuMart_MVC_3.Models;

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

            var products = _context.productinfo
                .Include(p => p.Urls)
                .ToList();

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
        public IActionResult Create(IProduct product)
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
        public IActionResult Update(IProduct product)
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
        public IActionResult Remove(IProduct product)
        {
            if (!(IsAdmin()))
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            _context.productinfo.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

   
        public IActionResult Details(int id)
        {
            var product = _context.productinfo.FirstOrDefault(p => p.productid == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult ICreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ICreate(IProduct product, IEnumerable<IFormFile> images)
        {
            try
            {
                product.updatedAt = DateTime.Now;

                // Add product to the database first
                _context.productinfo.Add(product);
                _context.SaveChanges(); // This will set the productid of the product

                string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                // Ensure the directory exists
                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }

                foreach (var image in images)
                {
                    if (image.Length > 0)
                    {
                        string filePath = Path.Combine(imagesPath, image.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }

                        var imageUrl = new ImageUrl
                        {
                            productid = product.productid, // Reference the correct productid
                            imageurl = "images/" + image.FileName
                        };

                        _context.imageurl.Add(imageUrl);
                    }
                }

                // Save image URL data to the database
                _context.SaveChanges();

                ViewBag.Message = "Product created successfully.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "An error occurred: " + ex.Message;
            }

            return View();
        }


    }
}
