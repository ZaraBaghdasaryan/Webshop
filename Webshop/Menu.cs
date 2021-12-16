using BicycleRental.Methods;
using System;
using System.Collections.Generic;
using System.Text;
using webshop.models;
using Webshop.Methods;
using Webshop.Models;

namespace Webshop
{
    public class Menu
    {
        public void DisplaMainMenu()
        {
            CustomerMethods customerMethods = new CustomerMethods();
            ShoppingCartMethods shoppingCartMethods = new ShoppingCartMethods();
            OrderMethods order = new OrderMethods();
            OrderProductMethods orderProductMethods = new OrderProductMethods();

            Console.Clear();
            Console.WriteLine("Here are your options:");
            Console.WriteLine("1. Browse products");
            Console.WriteLine("2. Checkout");
            Console.WriteLine("3. Sign in / Login");

            string choice = Console.ReadLine().Substring(0);

            switch(choice)
            {
                case "1":
                    orderProductMethods.CreateOrderProduct();
                    break;
                case "2":
                    order.CreateNewOrder();
                    break;
                case "4":
                    DisplayLoginSignUpMenu();
                    break;

            }
        }

        public void DisplayLoginSignUpMenu()
        {
            Console.Clear();
            CustomerMethods customerMethods = new CustomerMethods();

            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Log in");
            Console.WriteLine("3. Log out");
            Console.WriteLine("4. Go back to main menu");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Clear();
                customerMethods.SignUp();
            }
            else if (choice == 2)
            {
                Console.Clear();
                customerMethods.LogIn();
            }
            else if (choice == 3)
            {
                Console.Clear();
                customerMethods.LogOut();
            }
            else if (choice == 4)
            {
                Console.Clear();
                DisplaMainMenu();
            }

        }
        public void DisplayProductsMenu()
        {
            ProductMethods product = new ProductMethods();
            OrderMethods order = new OrderMethods();
            OrderProductMethods orderProduct = new OrderProductMethods();
            product.GetAllProducts(false);
        }

        public void GoBackToMain()
        {
            ProductMethods product = new ProductMethods();

            Console.Clear();
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
