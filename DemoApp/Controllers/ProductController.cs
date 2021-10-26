using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<ProductModel> prodList = new List<ProductModel>();

            prodList.Add(new ProductModel { Id = 1, Name = "Gaming Controller", Price = 999, Description = "Used to play games" });

            prodList.Add(new ProductModel { Id = 2, Name = "Gaming Controller", Price = 999, Description = "Used to play games" });

            prodList.Add(new ProductModel { Id = 3, Name = "Gaming Controller", Price = 999, Description = "Used to play games" });


            return View(prodList);
        }

        public IActionResult Message()
        {
            return View("message");
        }

        public IActionResult Welcome(string name, int secretNumber=13)
        {
            ViewBag.Name = name;
            ViewBag.Secret = secretNumber;
            return View();
        }


    }
}
