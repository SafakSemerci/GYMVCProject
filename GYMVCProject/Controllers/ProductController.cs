﻿using GYMVCProject.Helpers;
using GYMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace GYMVCProject.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private IHelper _helper;

        public ProductController(AppDbContext context, IHelper helper)
        {
            _context = context;
            _helper = helper;
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
            var deletedData = _context.Products.Find(id);
            _context.Products.Remove(deletedData);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Products updateProducts)
        {
            _context.Update(updateProducts);
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarıyla Güncellendi.";
            return RedirectToAction("Index");
        }


        [HttpPost]
        //public IActionResult Add(string Name, decimal Price, int Stock)// Second Road.
        public IActionResult Add(Products newProducts)
        {
            //First Road
           //var name=  HttpContext.Request.Form["Name"];
           //var price= decimal.Parse(HttpContext.Request.Form["Price"].ToString());
           //var stock= int.Parse(HttpContext.Request.Form["Stock"].ToString());

            // Add new product from page.
            //Second road is parameters to the function.
           //
           //
           //Products newProducts = new Products() { Name = Name, Price = Price, Stock = Stock };


            _context.Products.Add(newProducts);
            //Save the new product
            _context.SaveChanges();

            TempData["status"] = "Ürün Başarıyla Eklendi.";

            return RedirectToAction("Index");
        }


    }
}
