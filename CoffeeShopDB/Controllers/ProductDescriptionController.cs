using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopDB.Controllers
{
    public class ProductDescriptionController : Controller
    {
        public IActionResult index()
        {
            return View();
        }
    }
}