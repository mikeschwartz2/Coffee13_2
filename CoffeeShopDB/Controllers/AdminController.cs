using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoffeeShopDB.Controllers
{
    public class AdminController : Controller
    {
        IConfiguration ConfigRoot;
        DAL dal;

        public AdminController(IConfiguration config)
        {
            ConfigRoot = config;
            dal = new DAL(ConfigRoot.GetConnectionString("coffeeShopDB"));
        }

        public IActionResult Index()
        {
            ViewData["Products"] = dal.GetProductsAll();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Product prod)
        {

            int result = dal.CreateProduct(prod);

            if (result == 1)
            {
                TempData["UserMsg"] = "Item successfully added";
            }
            else
            {
                TempData["UserMsg"] = "Item not added";
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddForm()
        {
            Product prod = new Product();

            return View(prod);
        }

        public IActionResult Delete(int id)
        {
            int result = dal.DeleteProductById(id);

            if (result == 1)
            {
                TempData["UserMsg"] = "Item successfully deleted";
            }
            else
            {
                TempData["UserMsg"] = "Item for deletion not found";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = dal.GetProductById(id);

            if (prod == null)
            {
                return View("NoSuchItem");
            }
            else
            {
                return View(prod);
            }
        }

        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            int result = dal.UpdateProductById(prod);

            if (result == 1)
            {
                TempData["UserMsg"] = "Item successfully updated";
            }
            else
            {
                TempData["UserMsg"] = "Item not updated";
            }

            return RedirectToAction("Index");
        }
    }
}