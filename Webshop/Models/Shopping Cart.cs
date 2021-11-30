using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class Shopping_Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; } 

        public IEnumerable<Product> Products { get; set; }


    }
}
