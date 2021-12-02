﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webshop.Models;

namespace Webshop.Methods
{
    public class OrderProductMethods
    {

        public void CreateOrderProduct()
        {

            using(WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                webshopDBContext.Products.Load();
                webshopDBContext.OrderProducts.Load();
                webshopDBContext.Orders.Load();

                Menu menu = new Menu();

                Console.WriteLine("Which product do you want?");
                int choice = Convert.ToInt32(Console.ReadLine());

                

                Console.WriteLine("How many do you want?");
                int quantitychosen = Convert.ToInt32(Console.ReadLine());

                webshopDBContext.Products.Find(choice).Availability -= quantitychosen;


                var newOrderProduct = new OrderProducts()
                    {
                        Products = webshopDBContext.Products.Where(p => p.ProductId == choice).FirstOrDefault(),
                        ProductId = webshopDBContext.Products.Where(p => p.ProductId == choice).FirstOrDefault().ProductId,
                        Quantity = quantitychosen,
                        OrderProductsPrice = webshopDBContext.Products.Find(choice).Price,
                        IsActive = true
                    };

                    webshopDBContext.OrderProducts.Add(newOrderProduct);
                    webshopDBContext.SaveChanges();

                    Console.WriteLine("OrderProduct has been created. Do you want to continue shopping?");
                    Console.WriteLine($"Product: {newOrderProduct.ProductId} \nQuantity: {newOrderProduct.Quantity}");
                    Console.WriteLine("Press any key to go back to main menu.");
                    Console.ReadKey();
                    menu.DisplayProductsMenu();


                //}
                //else
                //{
                //    var orderproduct = webshopDBContext.OrderProducts.Where(o => o.IsActive == true).FirstOrDefault();

                //    orderproduct.Products.Add(new Product { ProductName = webshopDBContext.Products.Find(choice).ProductName.ToString(), ProductId = webshopDBContext.Products.Where(p => p.ProductId == choice).FirstOrDefault().ProductId, Price = webshopDBContext.Products.Find(choice).Price });

                //    webshopDBContext.OrderProducts.Add(orderproduct);
                //    webshopDBContext.SaveChanges();

                //    Console.WriteLine("OrderProduct has been created. Do you want to continue shopping?");
                //    Console.WriteLine("Press 1 for yes or 2 for no. If you press 2 you will go to checkout and end process your order.");

                //    choice = Convert.ToInt32(Console.ReadLine());

                //    if (choice == 1)
                //    {
                //        menu.DisplayProductsMenu();

                //    }
                //    else
                //    {
                //        menu.GoBackToMain();
                //    }
                //}

                
            }
        }
    }
}
