using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Methods;

namespace Webshop
{
    public class Menu
    {
        public void DisplaMainMenu()
        {
            ProductMethods product = new ProductMethods();
            OrderMethods order = new OrderMethods();

            Console.WriteLine("Here are your options:");
            Console.WriteLine("1. Browse products");
            Console.WriteLine("2. Go to Shopping Cart");
            Console.WriteLine("3. Sign in / Login");

            string choice = Console.ReadLine().Substring(0);

            switch(choice)
            {
                case "1":
                    product.GetAllProducts(false);
                    Console.WriteLine("Which product do you want to buy?");
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    order.AddProductToOrder(userInput);
                    break;
            }
        }

        public void DisplayProductsMenu()
        {

        }
    }
}
