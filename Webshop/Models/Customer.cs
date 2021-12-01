using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [MaxLength(150), Required]
        public string Email { get; set; }
        public bool IsLoggedin { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        public IEnumerable<Order> Orders { get; set; } 

    }
}
 