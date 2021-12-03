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

                var customer = new Customer();


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



                Console.WriteLine("Order was created!");
                Console.WriteLine($"OrderId: {order.OrderId} \n Total Price: {order.TotalPrice}");

                Console.WriteLine("\n Press any key to continue");
                Console.ReadKey();
                menu.GoBackToMain();

            }
        }




































        //public void CreateOrder()

        //{
        //    WebshopDBContext webshopDBContext = new WebshopDBContext();

        //    var order = new Order();
        //    var product = new Product();
        //    var customer = new Customer();

        //    Console.WriteLine("Please, enter the Price of the order.");
        //    int Price = product.Price;
        //    Console.WriteLine($"Price: {Price}.");
        //    int CustomerId = customer.Id;
        //    Console.WriteLine($"CustomerId: {CustomerId}");
        //    int ProductId = product.ProductId;


        //    bool x = true;

        //    while (x == true)
        //    {
        //        Console.WriteLine("Press 1 to add product and press 2 to exit.");
        //        var input = Console.ReadLine();
        //        switch (input)

        //        {
        //            case "1":
        //                Console.WriteLine("Please, choose a productId to add a product");

        //                var productId = Convert.ToInt32(Console.ReadLine());

        //                var listofproducts = webshopDBContext.Products.Where(b => b.ProductId == productId).ToList();

        //                order.OrderProducts = listofproducts;
        //                break;

        //            case "2":

        //                x = false;

        //                break;
        //        }
        //    }


        //    order.TotalPrice = Price;


        //    Console.WriteLine("Well done! A new Order with its properties has been added to the database! Press enter if you want to return to the main menu.");
        //    webshopDBContext.Add(order);
        //    try
        //    {
        //        webshopDBContext.SaveChanges();

        //    }

        //    catch (DbUpdateConcurrencyException exception)
        //    {
        //        Console.WriteLine($"Something went wrong. Sorry. Try again later.{exception}");
        //    }

        //    Console.ReadKey();

        //}

        //public void UpdateOrder() 
        //{
        //    WebshopDBContext webshopDBContext = new WebshopDBContext();

        //    Console.WriteLine("Please, enter OrderId."); 
        //    var orderId = Convert.ToInt32(Console.ReadLine());
        //    var order= webshopDBContext.Orders.Find(orderId);

        //    Console.WriteLine("Please, enter the new Price for the order. Current Price is:" + " " + order.TotalPrice);
        //    int Price2 = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Please, enter the new CustomerId for the order. Current CustomerId is:" + " " + order.CustomerId);
        //    int CustomerId2 = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Please, enter the new ProductId for the order. Current ProductId is:" + " " + order.CustomerId);
        //    int ProductId2 = Convert.ToInt32(Console.ReadLine());

        //    order.TotalPrice = Price2;
        //    order.CustomerId = CustomerId2;
        //    order.ProductId = ProductId2;
           

        //    Console.WriteLine("Well done! The updated Order has been added to the database! Press enter if you want to return to the main menu.");
        //    webshopDBContext.Update(order);
        //    try
        //    {
        //        webshopDBContext.SaveChanges();

        //    }

        //    catch (DbUpdateConcurrencyException exception)
        //    {
        //        Console.WriteLine($"Something went wrong. Sorry. Try again later.{exception}");
        //    }

        //    Console.ReadKey();
        //}
        //public async Task<Order> ReadOrder() 
        //{
        //    WebshopDBContext webshopDBContext = new WebshopDBContext();

        //    Console.WriteLine("Please, enter OrderId.");
        //    var orderId = Convert.ToInt32(Console.ReadLine());
        //    var order= await webshopDBContext.Orders.Include(x => x.Customer).Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == orderId);

        //    if (order == null)
        //    {

        //        Console.WriteLine("OrderId was not found.");

        //    }

        //    if (order != null)
        //    {
                
        //        Console.WriteLine("Price is:" + " " + order.TotalPrice);
        //        Console.WriteLine("CustomerId is:" + " " + order.CustomerId);
        //        Console.WriteLine("ProductId is:" + " " + order.ProductId);

        //    }

        //    foreach (var product in order.Products)
        //    {

        //        Console.WriteLine(product.ProductName);
        //        Console.WriteLine(product.Price);
        //        Console.WriteLine(product.Category);
        //        Console.WriteLine(product.Availability);

        //    }

        //    Console.ReadKey();
        //    return order;

        //}
        //public void DeleteOrder() 
        //{
        //    WebshopDBContext webshopDBContext = new WebshopDBContext();

        //    Console.WriteLine("Please, enter OrderId.");
        //    var orderId = Convert.ToInt32(Console.ReadLine());
        //    var order = webshopDBContext.Orders.Find(orderId);
             
        //    try
        //    {

        //        webshopDBContext.Remove(order);
        //        webshopDBContext.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException exception)

        //    {
        //        Console.WriteLine($"Something went wrong. Sorry. Try again later.{exception}"); //Save info about the error in the variable
        //    }

        //    Console.WriteLine("Oops, the Order has been deleted now. Hope that's what you wanted :P. Press enter if you want to return to the main menu.");
        //    Console.ReadKey();
        //}


    }
}
