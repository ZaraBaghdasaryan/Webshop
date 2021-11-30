using System;
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

        [MaxLength(150), Required]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; } //One category having many products
    }
}
