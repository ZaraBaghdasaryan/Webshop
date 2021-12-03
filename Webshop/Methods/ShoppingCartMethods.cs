using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using webshop;
using webshop.models;
using Webshop;
using Webshop.Methods;
using Webshop.Models;

namespace webshop.models
{
    public class ShoppingCartMethods
    {

        public void CreateShoppingCart()
        {
            using(WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                webshopDBContext.Products.Load();
                webshopDBContext.OrderProducts.Load();
                webshopDBContext.Customers.Load();
                webshopDBContext.Orders.Load();

                OrderProductMethods orderProdctMethod = new OrderProductMethods();

                Menu menu = new Menu();

                var customer = new Customer();

                var activeshoppingCart = webshopDBContext.ShoppingCarts.Where(o => o.IsActive == true).FirstOrDefault();

                    var shoppingCart = new ShoppingCart()
                    {
                        OrderProducts = webshopDBContext.OrderProducts.Where(o => o.IsActive == true).ToList(),
                        TotalPrice = CalculateTotal(),
                        IsActive = true
                    };

                    webshopDBContext.ShoppingCarts.Add(shoppingCart);
                    webshopDBContext.SaveChanges();
                    var updatedOP = webshopDBContext.OrderProducts.Where(o => o.IsActive == true).FirstOrDefault().IsActive = false;
                    webshopDBContext.SaveChanges(updatedOP);

                    Console.WriteLine("Order was created!");
                    Console.WriteLine($"CartId: {shoppingCart.ShoppingCartId} \n Total Price: {shoppingCart.TotalPrice} \n Customer: {shoppingCart.OrderProducts}");

                    Console.WriteLine("\n Press any key to continue");
                    Console.ReadKey();
                    menu.GoBackToMain();
                
            }
        }

        public void AddOrderProductToCart(OrderProducts orderProducts)
        {
            using (WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                webshopDBContext.OrderProducts.Load();

                var findProduct = webshopDBContext.OrderProducts.Where(o => o.IsActive == true).FirstOrDefault();

                


                webshopDBContext.SaveChanges();
            }
        }

        public int CalculateTotal()
        {
            using (WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                int totalPrice = 0;
                webshopDBContext.Products.Load();
                webshopDBContext.OrderProducts.Load();

                var product = webshopDBContext.OrderProducts.Where(o => o.IsActive == true).FirstOrDefault();

                var pricePerLine = product.OrderProductsPrice;
                var qty = webshopDBContext.OrderProducts.Where(o => o.IsActive == true).FirstOrDefault().Quantity;

                totalPrice = pricePerLine * qty;

                return totalPrice;
            }
        }




















        //Menu menu = new Menu();
        //public List<Product> Cartlist = new List<Product>();

        //public void AddToShoppingCart()
        //{
        //    Cartlist.Add(new Product(false));
        //    Console.WriteLine("you have just added the product/products to your shopping cart!");
        //    Console.WriteLine("press any key to continue shopping.");
        //    Console.ReadKey();
        //    menu.DisplaMainMenu();
        //}

        //public void RemoveFromShoppingCart()
        //{
        //    {
        //        var last = Cartlist.Count() - 1;
        //        Cartlist.RemoveAll(r => Cartlist[last].ProductId == r.ProductId);
        //    }
        //    Console.WriteLine("The shopping cart has been emptied.");
        //    Console.WriteLine("Press any key to continue shopping.");
        //    Console.WriteLine();
        //    menu.DisplaMainMenu();
        //}

        //public void PrintCart(List<Product> Cartlist)
        //{
        //    Console.Clear();
        //    for (int i = 0; i < Cartlist.Count; i++)
        //    {
        //        Console.WriteLine(Cartlist[i].PrintProducts());
        //    }
        //    double total = 0;
        //    for (int i = 0; i < Cartlist.Count; i++)
        //    {
        //        total = total + Cartlist[i].Price;

        //    }
        //    Console.WriteLine("\n-----------------------------");
        //    Console.WriteLine($"\nshopping cart total: {total}:-");
        //    Console.WriteLine("\n-----------------------------");

        //    Console.WriteLine("\n1. checkout");
        //    Console.WriteLine("\n2. empty cart");
        //    Console.WriteLine("\n3. go back");
        //    var input = Convert.ToInt32(Console.ReadLine());

        //    while (true)
        //    {
        //        if (input == 1)
        //        {
        //            Checkout();
        //            break;
        //        }
        //        else if (input == 2)
        //        {
        //            RemoveFromShoppingCart();
        //            break;
        //        }
        //        else if (input == 3)
        //        {
        //            //go back
        //            menu.DisplaMainMenu();
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Please, type in only numbers.");
        //        }
        //    }
        //}

        //public void Checkout()
        //{
        //    Order neworder = new Order(Cartlist); //Customer.Address, Customer.FirstName can't be used unless static, but that creates a conflict in the Sign Up method
        //    neworder.PrintReciept();
        //    Console.WriteLine("Press any key to continue shopping.");
        //    Console.ReadKey();
        //    menu.DisplaMainMenu();
        //    Cartlist.Clear();
        //}
    }
}
