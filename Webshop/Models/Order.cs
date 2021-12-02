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
        private List<Product> cartlist;
        private string address;
        private string firstName;

        public Order()
        {
        }

        public Order(List<Product> cartlist)
        {
            this.cartlist = cartlist;
        }

        public Order(List<Product> cartlist, string address, string firstName)
        {
            this.cartlist = cartlist;
            this.address = address;
            this.firstName = firstName;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; } 

        public List<Product> Products { get; set; }


        public void PrintReciept()
        {
            Console.Clear();            
            Console.WriteLine($"Thank you for your order! Your order number is: {Id}");        
            Console.WriteLine($"Total price: {TotalPrice}:-");
            Console.WriteLine(" ");
        }
    }
}
