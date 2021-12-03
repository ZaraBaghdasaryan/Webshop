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

        public ShoppingCart ShoppingCart { get; set; }

        public bool IsActive { get; set; }

        public Product Products { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
