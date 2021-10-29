using Bogus;
using DemoApp.Models;
using DemoApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            ProductsDAO products = new ProductsDAO();

            return View(products.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            ProductsDAO products = new ProductsDAO();

            List<ProductModel> prodList = products.SearchProducts(searchTerm);
            return View("index", prodList);
        }

        public IActionResult ShowDetails(int id)
        {
            ProductsDAO product = new ProductsDAO();
            ProductModel foundProduct = product.GetProductById(id);
            return View(foundProduct);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View("ShowEdit", foundProduct);
        }

        [HttpPost]
        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult Delete(int Id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(Id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");  
        }

        [HttpPost]
        public IActionResult ProcessCreate(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();

            products.Insert(product);

            return View("Index", products.GetAllProducts());
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
