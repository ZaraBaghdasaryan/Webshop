using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class Order
    {

        [Key]
        public int OrderId { get; set; }

        [Required]
        public int TotalPrice { get; set; }
        public int Quantity { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }
        

    }
}
