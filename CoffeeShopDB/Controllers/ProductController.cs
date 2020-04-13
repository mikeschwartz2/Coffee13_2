using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using CoffeeShopDB.Models;

namespace CoffeeShopDB.Controllers
{
    public class ProductController : Controller
    {

        IConfiguration ConfigRoot;
        DAL dal;

        public ProductController(IConfiguration config)
        {
            ConfigRoot = config;
            dal = new DAL(ConfigRoot.GetConnectionString("coffeeShopDB"));
        }
        public IActionResult Index()
        {
            ViewData["Products"] = dal.GetProductsAll();

            return View();
        }

    }
}