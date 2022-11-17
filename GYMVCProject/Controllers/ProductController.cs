using AutoMapper;
using GYMVCProject.Helpers;
using GYMVCProject.Models;
using GYMVCProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Composition;

namespace GYMVCProject.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;


        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList(); 



            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult Add()
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new() {Data="Mavi", Value="Mavi"},
                new() {Data="Kırmızı", Value="Kırmızı"},
                new() {Data="Sarı", Value="Sarı"},

            },"Value","Data");



            return View();
        }

        public IActionResult Remove(int id)
        {
            var deletedData = _context.Products.Find(id);
            _context.Products.Remove(deletedData);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.Expirevalue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new() {Data="Mavi", Value="Mavi"},
                new() {Data="Kırmızı", Value="Kırmızı"},
                new() {Data="Sarı", Value="Sarı"},

            }, "Value", "Data",product.Color);



            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProducts)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Expirevalue = updateProducts.Expire;
                ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 }
            };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new() {Data="Mavi", Value="Mavi"},
                new() {Data="Kırmızı", Value="Kırmızı"},
                new() {Data="Sarı", Value="Sarı"},

            }, "Value", "Data", updateProducts.Color);
                return View();
            }
            else
            {

                _context.Update(_mapper.Map<Products>(updateProducts));
                _context.SaveChanges();
                TempData["status"] = "Ürün Başarıyla Güncellendi.";
                return RedirectToAction("Index");

            }


        }


        [HttpPost]
        //public IActionResult Add(string Name, decimal Price, int Stock)// Second Road.
        public IActionResult Add(ProductViewModel newProducts)
        {
            //First Road
            //var name=  HttpContext.Request.Form["Name"];
            //var price= decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock= int.Parse(HttpContext.Request.Form["Stock"].ToString());

            // Add new product from page.
            //Second road is parameters to the function.
            //
            //
            //_context.Products.Add(newProducts);
            //Products newProducts = new Products() { Name = Name, Price = Price, Stock = Stock };

            //Validation is ok its continue.
            if (ModelState.IsValid)
            {
                _context.Products.Add(_mapper.Map<Products>(newProducts));

                //Save the new product
                _context.SaveChanges();

                TempData["status"] = "Ürün Başarıyla Eklendi.";

                return RedirectToAction("Index");
            }
            else

            if (!string.IsNullOrEmpty(newProducts.Name) && newProducts.Name.StartsWith("A"))
            {
                ModelState.AddModelError(String.Empty, "Ürün Adı A Harfi ile başlayamaz.");

            }



            {
                ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 }
            };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
                    {
                new() {Data="Mavi", Value="Mavi"},
                new() {Data="Kırmızı", Value="Kırmızı"},
                new() {Data="Sarı", Value="Sarı"},

                    }, "Value", "Data");




                return View();
            }
            }


        
        }


    }

