using Webshop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Webshop;
using System.Collections.Generic;
using BicycleRental.Methods;

namespace Webshop.Methods 
{
    public class OrderMethods
    {

        public void CreateNewOrder()
        {
            using(WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                webshopDBContext.Products.Load();
                webshopDBContext.OrderProducts.Load();
                webshopDBContext.Customers.Load();
                webshopDBContext.Orders.Load();

                Menu menu = new Menu();


                var customer = webshopDBContext.Customers.Where(c => c.IsLoggedin == true).Count();


                if (customer.Equals(1))
                {


                    var order = new Order()
                    {
                        ShoppingCart = webshopDBContext.ShoppingCarts.Where(s => s.IsActive == true).FirstOrDefault(),
                        ShoppingCartId = webshopDBContext.ShoppingCarts.Where(s => s.IsActive == true).FirstOrDefault().ShoppingCartId,
                        Customer = webshopDBContext.Customers
                        .Where(c => c.IsLoggedin == true).FirstOrDefault(),
                        CustomerId = webshopDBContext.Customers
                        .Where(c => c.IsLoggedin == true).FirstOrDefault().Id,
                        TotalPrice = webshopDBContext.ShoppingCarts.Where(s => s.IsActive == true).FirstOrDefault().TotalPrice,
                        Quantity = webshopDBContext.ShoppingCarts.Where(s => s.IsActive == true).FirstOrDefault().OrderProducts.Count

                    };
                    webshopDBContext.Orders.Add(order);
                    webshopDBContext.SaveChanges();

                    var updatedOP = webshopDBContext.ShoppingCarts.Where(o => o.IsActive == true).FirstOrDefault().IsActive = false;
                    webshopDBContext.SaveChanges(updatedOP);


                    Console.Clear();
                    Console.WriteLine("Order was created!");
                    Console.WriteLine($"OrderId: {order.OrderId} \n Total Price: {order.TotalPrice}");

                    Console.WriteLine("\n Press any key to continue");
                    Console.ReadKey();
                    menu.GoBackToMain();
                }
                else
                {
                    ProductMethods product = new ProductMethods();
                    Console.Clear();
                    product.ResetAvailabilityWhenClosing();
                    Console.WriteLine("Sorry, but you must be logged in before you can make a purchase");
                    Console.WriteLine("\nPlease login");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    menu.DisplaMainMenu();
                }
            }
        }
    }
}
