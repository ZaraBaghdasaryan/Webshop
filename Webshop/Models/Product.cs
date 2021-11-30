using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Availability { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
