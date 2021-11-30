using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Webshop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }
        public IEnumerable<Product> Products  { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
