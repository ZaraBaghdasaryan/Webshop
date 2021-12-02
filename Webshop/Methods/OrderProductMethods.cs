using Microsoft.EntityFrameworkCore;
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

                webshopDBContext.Products.Find(choice).Availability -= choice;


               var product = webshopDBContext.OrderProducts.Where(o => o.IsActive == true).FirstOrDefault();

                //if(product == null)
                //{
                    var newOrderProduct = new OrderProducts()
                    {
                        Products = webshopDBContext.Products.Where(p => p.ProductId == choice).ToList(),
                        ProductName = webshopDBContext.Products.Find(choice).ProductName.ToString(),
                        OrderProductsPrice = webshopDBContext.Products.Find(choice).Price,
                        IsActive = true
                    };

                    webshopDBContext.OrderProducts.Add(newOrderProduct);
                    webshopDBContext.SaveChanges();
                    Console.WriteLine("OrderProduct has been created. Do you want to continue shopping?");
                    Console.WriteLine($"");
                    Console.WriteLine("Press 1 for yes or 2 for no. If you press 2 you will go to checkout and end process your order.");

                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        menu.DisplayProductsMenu();

                    }
                    else
                    {
                        menu.GoBackToMain();
                    }

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
