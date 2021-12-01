using BicycleRental.Methods;
using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Methods;
using Webshop.Models;

namespace Webshop
{
    public class Menu
    {
        public void DisplaMainMenu()
        {
            CustomerMethods customerMethods = new CustomerMethods();
            Console.Clear();
            Console.WriteLine("Here are your options:");
            Console.WriteLine("1. Browse products");
            Console.WriteLine("2. Go to Shopping Cart");
            Console.WriteLine("3. Sign in / Login");

            string choice = Console.ReadLine().Substring(0);

            switch(choice)
            {
                case "1":
                    DisplayProductsMenu();
                    break;
                case "2":
                    break;
                case "3":
                    customerMethods.SignUp();
                    break;

            }
        }

        public void DisplayProductsMenu()
        {
            ProductMethods product = new ProductMethods();
            OrderMethods order = new OrderMethods();
            product.GetAllProducts(false);
            order.CreateNewOrder();
        }

        public void GoBackToMain()
        {
            ProductMethods product = new ProductMethods();

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Go back");
            Console.WriteLine("2. Exit Program");

            int choice = Convert.ToInt32(Console.ReadLine());

            if(choice == 1)
            {
                Console.Clear();
                DisplaMainMenu();
            }
            else if (choice == 2)
            {
                product.ResetAvailabilityWhenClosing();
                Environment.Exit(0);
            }
        }
    }
}
