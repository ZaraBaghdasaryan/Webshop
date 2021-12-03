using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using webshop.models;
using Webshop.Models;

namespace Webshop.Methods
{
    public class OrderProductMethods
    {

        public void CreateOrderProduct()
        {

            using(WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                ShoppingCartMethods shoppingCartMethods = new ShoppingCartMethods();


                webshopDBContext.Products.Load();
                webshopDBContext.OrderProducts.Load();
                webshopDBContext.Orders.Load();

                Menu menu = new Menu();

                int choice = GetChosenProduct();
                int quantitychosen = GetChosenQuantity();

                webshopDBContext.Products.Find(choice).Availability -= quantitychosen;


                var newOrderProduct = new OrderProducts()
                {
                        Products = webshopDBContext.Products.Where(p => p.ProductId == choice).FirstOrDefault(),
                        ProductId = webshopDBContext.Products.Where(p => p.ProductId == choice).FirstOrDefault().ProductId,
                        ProductName = webshopDBContext.Products.Where(p => p.ProductId == choice).FirstOrDefault().ProductName,
                        Quantity = quantitychosen,
                        OrderProductsPrice = webshopDBContext.Products.Find(choice).Price * quantitychosen,
                        IsActive = true
                };

                webshopDBContext.OrderProducts.Add(newOrderProduct);
                webshopDBContext.SaveChanges();


                shoppingCartMethods.CreateShoppingCart();

                Console.WriteLine("OrderProduct has been created. Do you want to continue shopping?");
                Console.WriteLine($"Product: {newOrderProduct.ProductId} \nQuantity: {newOrderProduct.Quantity}");
                Console.WriteLine("Press any key to go back to main menu.");
                Console.ReadKey();
                menu.DisplaMainMenu();
            }
        }

        public int GetChosenProduct()
        {

            Console.WriteLine("Which product do you want?");
            int choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        public int GetChosenQuantity()
        {
            Console.WriteLine("How many do you want?");
            int quantitychosen = Convert.ToInt32(Console.ReadLine());

            return quantitychosen;
              
        }


    }
}
