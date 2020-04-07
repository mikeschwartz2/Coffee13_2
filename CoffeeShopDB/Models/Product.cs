using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopDB.Models
{
    public class Product
    {
        private int id;
        private string productName;
        private double price;
        private string description;
        private string category;

        public int Id { get => id; set => id = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Category { get => category; set => category = value; }
    }
}
