using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; } 
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Availability { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}


