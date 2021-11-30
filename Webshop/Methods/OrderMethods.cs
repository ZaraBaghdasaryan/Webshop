using Webshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Webshop;
using System.Collections.Generic;

namespace Webshop.Methods 
{
    public class OrderMethods
    {
        public IEnumerable<Order> AddProductToOrder(int userInput)
        {
            WebshopDBContext webshopDBContext = new WebshopDBContext();

            var order = new Order();
            var product = new Product();
            var customer = new Customer();


            var products = webshopDBContext.Products.Where(b => b.ProductId == userInput).ToList();
            var customers = webshopDBContext.Customers.Find(customer.IsLoggedin == true);

            int id = +1;

            order.Customer = customers;
            order.Products = products;
            order.ProductId = product.ProductId;
            order.Id = id;
            Console.WriteLine("Succesfully created you order!");
            Console.WriteLine($"Id: {id}");
            webshopDBContext.Add(order);
            webshopDBContext.SaveChanges();

            return AddProductToOrder(userInput);
        }


        //public decimal Checkout (Order order)
        //{


        //    return order;
        //}
        public void CreateOrder()

        {
            WebshopDBContext webshopDBContext = new WebshopDBContext();

            var order = new Order();

            Console.WriteLine("Please, enter the Price of the order.");
            int Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, enter the CustomerId of the order.");
            int CustomerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, enter the ProductId of the order.");
            int ProductId = Convert.ToInt32(Console.ReadLine());


            bool x = true;

            while (x == true)
            {
                Console.WriteLine("Press 1 to add product and press 2 to exit.");
                var input = Console.ReadLine();
                switch (input)

                {
                    case "1":
                        Console.WriteLine("Please, choose a productId to add a product");

                        var productId = Convert.ToInt32(Console.ReadLine());

                        var listofproducts = webshopDBContext.Products.Where(b => b.ProductId == productId).ToList();

                        order.Products = listofproducts;
                        break;

                    case "2":

                        x = false;

                        break;
                }
            }


            order.CustomerId = CustomerId;
            order.TotalPrice = Price;
            order.ProductId = ProductId;


            Console.WriteLine("Well done! A new Order with its properties has been added to the database! Press enter if you want to return to the main menu.");
            webshopDBContext.Add(order);
            try
            {
                webshopDBContext.SaveChanges();

            }

            catch (DbUpdateConcurrencyException exception)
            {
                Console.WriteLine($"Something went wrong. Sorry. Try again later.{exception}");
            }

            Console.ReadKey();

        }

        public void UpdateOrder() 
        {
            WebshopDBContext webshopDBContext = new WebshopDBContext();

            Console.WriteLine("Please, enter OrderId."); 
            var orderId = Convert.ToInt32(Console.ReadLine());
            var order= webshopDBContext.Orders.Find(orderId);

            Console.WriteLine("Please, enter the new Price for the order. Current Price is:" + " " + order.TotalPrice);
            int Price2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, enter the new CustomerId for the order. Current CustomerId is:" + " " + order.CustomerId);
            int CustomerId2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, enter the new ProductId for the order. Current ProductId is:" + " " + order.CustomerId);
            int ProductId2 = Convert.ToInt32(Console.ReadLine());

            order.TotalPrice = Price2;
            order.CustomerId = CustomerId2;
            order.ProductId = ProductId2;
           

            Console.WriteLine("Well done! The updated Order has been added to the database! Press enter if you want to return to the main menu.");
            webshopDBContext.Update(order);
            try
            {
                webshopDBContext.SaveChanges();

            }

            catch (DbUpdateConcurrencyException exception)
            {
                Console.WriteLine($"Something went wrong. Sorry. Try again later.{exception}");
            }

            Console.ReadKey();
        }
        public async Task<Order> ReadOrder() 
        {
            WebshopDBContext webshopDBContext = new WebshopDBContext();

            Console.WriteLine("Please, enter OrderId.");
            var orderId = Convert.ToInt32(Console.ReadLine());
            var order= await webshopDBContext.Orders.Include(x => x.Customer).Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {

                Console.WriteLine("OrderId was not found.");

            }

            if (order != null)
            {
                
                Console.WriteLine("Price is:" + " " + order.TotalPrice);
                Console.WriteLine("CustomerId is:" + " " + order.CustomerId);
                Console.WriteLine("ProductId is:" + " " + order.ProductId);

            }

            foreach (var product in order.Products)
            {

                Console.WriteLine(product.ProductName);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.Category);
                Console.WriteLine(product.Availability);

            }

            Console.ReadKey();
            return order;

        }
        public void DeleteOrder() 
        {
            WebshopDBContext webshopDBContext = new WebshopDBContext();

            Console.WriteLine("Please, enter OrderId.");
            var orderId = Convert.ToInt32(Console.ReadLine());
            var order = webshopDBContext.Orders.Find(orderId);
             
            try
            {

                webshopDBContext.Remove(order);
                webshopDBContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException exception)

            {
                Console.WriteLine($"Something went wrong. Sorry. Try again later.{exception}"); //Save info about the error in the variable
            }

            Console.WriteLine("Oops, the Order has been deleted now. Hope that's what you wanted :P. Press enter if you want to return to the main menu.");
            Console.ReadKey();
        }


    }
}
