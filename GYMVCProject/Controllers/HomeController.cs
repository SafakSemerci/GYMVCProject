using AutoMapper;
using GYMVCProject.Models;
using GYMVCProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GYMVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;


        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext, IMapper mapper = null)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _appDbContext.Products.OrderByDescending(x=>x.Id).Select(x=> new ProductPartialViewModel()
            {
                Id = x.Id,
                Name= x.Name,
                Price = x.Price,
                Stock = x.Stock

            }).ToList();

            ViewBag.productListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };

            return View();
        }

        public IActionResult Privacy()
        {
            var products = _appDbContext.Products.OrderByDescending(x => x.Id).Select(x => new ProductPartialViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock

            }).ToList();

            ViewBag.productListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Visitor()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SaveVisitorComment(VisitorViewModel visitorViewModel)        
        {
            try
            {
                var visitor = _mapper.Map<Visitor>(visitorViewModel);
                visitor.CreatedDate = DateTime.Now;
                _appDbContext.Visitors.Add(visitor);
                _appDbContext.SaveChanges();

                TempData["result"] = "Yorum Kayıt Edilmiştir.";

                return RedirectToAction(nameof(HomeController.Visitor));
            }
            catch (Exception)
            {
                TempData["result"] = "Yorum kaydedilirken bir hata meydana geldi.";
                return RedirectToAction(nameof(HomeController.Visitor));
            }



       


        }


    }
}