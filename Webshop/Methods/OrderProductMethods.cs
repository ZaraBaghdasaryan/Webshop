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

            using (WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                ShoppingCartMethods shoppingCartMethods = new ShoppingCartMethods();


                webshopDBContext.Products.Load();
                webshopDBContext.OrderProducts.Load();
                webshopDBContext.Orders.Load();

                Menu menu = new Menu();

                var orderProduct = webshopDBContext.ShoppingCarts.Where(o => o.IsActive == true).Count();

                if (orderProduct.Equals(0))
                {

                    menu.DisplayProductsMenu();

                    int choice = GetChosenProduct(false);
                    int quantitychosen = GetChosenQuantity(false);

                    webshopDBContext.Products.Find(choice).Availability -= quantitychosen;


                    var newOrderProduct = new OrderProducts()
                    {
                        Products = webshopDBContext.Products.Where(p => p.ProductId == choice).FirstOrDefault(),
                        ProductId = webshopDBContext.Products.Where(p => p.ProductId == choice).FirstOrDefault().ProductId,
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
                else
                {
                    Console.Clear();
                    Console.WriteLine("You already have an item in you cart. Please checkout before you add another...");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    menu.DisplaMainMenu();
                }
            }
        }

        public int GetChosenProduct(bool testing)
        {
            int choice = 0;

            if(testing == true)
            {
                 choice = 1;
                return choice;
            }
            else
            {
                Console.WriteLine("Which product do you want?");
                choice = Convert.ToInt32(Console.ReadLine());

                return choice;
            }
            
        }

        public int GetChosenQuantity(bool testing)
        {
            int quantitychosen = 0;


            if (testing == true)
            {
                quantitychosen = 1;
                return quantitychosen;
            }
            else
            {
                Console.WriteLine("How many do you want?");
                quantitychosen = Convert.ToInt32(Console.ReadLine());

                return quantitychosen;
            }
              
        }

    }
}
