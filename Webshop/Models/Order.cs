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
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }


        public IEnumerable<Product> Products { get; set; } 


    }
}
