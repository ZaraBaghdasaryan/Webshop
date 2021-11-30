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
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; } 

        [MaxLength(18), Required]
        public int Price { get; set; }

        [MaxLength(50), Required]
        public string Availability { get; set; }

        public Category Category { get; set; } //Association 

        public int CategoryId { get; set; } //Foreign Key   

        public IEnumerable<Order> Orders { get; set; } 

    }
}


