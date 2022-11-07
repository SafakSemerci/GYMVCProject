using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GYMVCProject.Controllers
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }

    }



    public class OrnekController : Controller
    {
        public IActionResult Index()
        {

            var productList = new List<Product>()
            {
                new(){id=1, Name="Kalem1"},
                new(){id=2, Name="Defter"},
                new(){id=3,Name="Silgi"}

            };

            //    //How to use ViewBag
            //    ViewBag.Name = "Asp.Net Core";
            //    //How to use View Data

            //    ViewData["age"] = 30;

            //    ViewData["names"] = new List<string>() { "ahmet", "mehmet", "hasan" };

            //Bir viewdan başka bir viewa data transfer etmek istiyorsak kullanıyoruz.
            //TempData["Surname"] = "yıldız";

            return View(productList);
        }

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult Index2()
        {
            // Başka bir sayfaya yönlendirmek istediğimizde kullanılıyor.
            return RedirectToAction("Index","Ornek");
           // return View();
        }

        //Parametre alan actionview
        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre", "Ornek", new { id = id });

        }

        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { Id = id });

        }



        //Geriye Content Döndürmek için kullanılıyor.
        public IActionResult ContentResult()
        {
            return Content("ContentResult");
        }
        //Geriye Json sayfası dönüşü yapmak için kullanılıyor.
        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, name = "Kalme1", price = 100 });

        }
        //Geriye boş dönmek için kullanılıyor.
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }


    }
}
