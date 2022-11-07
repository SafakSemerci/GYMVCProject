using GYMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace GYMVCProject.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;

            if (!_context.Products.Any())
            { 
                _context.Products.Add(new Products { Name = "kalem1", Price = 100, Stock = 300 });
                _context.Products.Add(new Products { Name = "kalem2", Price = 200, Stock = 300 });
                _context.Products.Add(new Products { Name = "kalem3", Price = 300, Stock = 300 });
                _context.SaveChanges();
            }

        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList(); ;
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Remove(int id)
        {
            _context.Remove(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult SaveProduct()
        {
           var name=  HttpContext.Request.Form["Name"];
           var price= HttpContext.Request.Form["Price"];
           var stock= HttpContext.Request.Form["Stock"];

            return View();
        }


    }
}
