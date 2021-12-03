using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }
        public bool IsActive { get; set; }
        public int TotalPrice { get; set; }

        public Order Order { get; set; }

    }
}
