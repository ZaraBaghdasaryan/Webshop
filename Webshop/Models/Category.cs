using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Webshop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<Product> Products  { get; set; }
    }
}
