using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Webshop.Models
{
    public class OrderProducts
    {
        [Key]
        public int OrderProductId { get; set; }

        public int OrderProductsPrice { get; set; }

        public Order Orders { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
        public string ProductName { get; set; }
    }
}
