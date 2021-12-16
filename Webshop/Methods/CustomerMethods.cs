using System;
using Webshop.Models;
using Microsoft.EntityFrameworkCore;
using Webshop;
using System.Linq;

namespace BicycleRental.Methods
{
    public class CustomerMethods
    {
        public void SignUp()

        {
            WebshopDBContext webshopDBContext = new WebshopDBContext();
            Menu menu = new Menu();
            Console.WriteLine("Write >back< if you want to go back");
            Console.WriteLine("\nPlease, enter your first name.");
            string FirstName = Console.ReadLine().ToLower();

            if(FirstName == "back")
            {
                menu.DisplayLoginSignUpMenu();
            }

            Console.WriteLine("Please, enter you last name.");
            string LastName = Console.ReadLine().ToLower();

            if (LastName == "back")
            {
                menu.DisplayLoginSignUpMenu();
            }

            Console.WriteLine("Please, enter your Email.");
            string Email = Console.ReadLine().ToLower();

            if (Email == "back")
            {
                menu.DisplayLoginSignUpMenu();
            }


            Console.WriteLine("Please. enter your password");
            string Password = Console.ReadLine().ToLower();

            if (Password == "back")
            {
                menu.DisplayLoginSignUpMenu();
            }

            Console.WriteLine("Please, enter your Address.");
            string Address = Console.ReadLine().ToLower();

            if (Address == "back")
            {
                menu.DisplayLoginSignUpMenu();
            }

            Customer customer = new Customer()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password,
                Address = Address,
                IsLoggedin = false
            };

            webshopDBContext.Customers.Add(customer);
            webshopDBContext.SaveChanges();

            Console.WriteLine("Welcome" + " " + FirstName + " " + LastName + " to our exciting store!");
            Console.WriteLine("Here is your account information:" + " " + "Username:" + " " + Email + " " + "Name:" + " " + FirstName + " " + LastName + " Adress: " + Address);

            Console.ReadKey();
            menu.DisplaMainMenu();
            Console.WriteLine("Please, press any key to go back to main menu");

        }

        public void LogIn()
        {
            using (WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                Console.WriteLine("Write >back< if you want to go back");
                Menu menu = new Menu();

                Console.WriteLine("Please, enter your Email.");
                string Email = Console.ReadLine().ToLower();

                if (Email == "back")
                {
                    menu.DisplayLoginSignUpMenu();
                }

                Console.WriteLine("Please, enter your password");
                string Password = Console.ReadLine().ToLower();

                if(Password == "back")
                {
                    menu.DisplayLoginSignUpMenu();
                }

                string lookForEmail = webshopDBContext.Customers
                    .Where(c => c.Email == Email).FirstOrDefault().Email;
                string lookForPassword = webshopDBContext.Customers
                    .Where(c => c.Password == Password).FirstOrDefault().Password;

                if (lookForEmail.Equals(Email) && lookForPassword.Equals(Password))
                {

                    var customer = webshopDBContext.Customers
                        .Where(c => c.Email == Email)
                        .FirstOrDefault();

                    customer.IsLoggedin = true;


                    Console.WriteLine($"Welcome {customer.FirstName}, you are now logged in!");
                    webshopDBContext.Customers.Update(customer);
                    webshopDBContext.SaveChanges();
                    Console.ReadKey();
                    menu.DisplayLoginSignUpMenu();
                }
                else
                {
                    Console.WriteLine("No user matching those credentials were found. Please try again");
                    LogIn();
                }

            }
        }

        public void LogOut()
        {
            Menu menu = new Menu();
            Order order = new Order();

            using (WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                Console.WriteLine("To log out press 1");
                var choice = Convert.ToInt32(Console.ReadLine());

                var customer = webshopDBContext.Customers.Where(c => c.IsLoggedin == true).FirstOrDefault().IsLoggedin = false;
                webshopDBContext.SaveChanges(customer);

                Console.WriteLine("Now you have logged out. Press any key to go back to the login menu");
                menu.DisplayLoginSignUpMenu();
            }
        }
    }
}


