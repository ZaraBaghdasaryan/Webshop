using System;
using Webshop.Models;
using Microsoft.EntityFrameworkCore;
using Webshop;
using System.Linq;

namespace BicycleRental.Methods
{
    public class CustomerMethods
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsLoggedin { get; set; }

        public void SignUp()

        {
            WebshopDBContext webshopDBContext = new WebshopDBContext();
            Menu menu = new Menu();

            Console.WriteLine("Please, enter your first name.");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Please, enter you last name.");
            string LastName = Console.ReadLine();
            Console.WriteLine("Please, enter your Email.");
            string Email = Console.ReadLine();
            Console.WriteLine("Please. enter your password");
            string Password = Console.ReadLine();
            Console.WriteLine("Please, enter your Address.");
            string Address = Console.ReadLine();

            Console.WriteLine("Welcome" + " " + FirstName + " " + LastName + " to our exciting store!");
            Console.WriteLine("Here is your account information:" + " " + "Username:" + " " + Email + " " + "Name:" + " " + FirstName + " " + LastName + " Adress: " + Address);

            Console.WriteLine("Please, press any key to go back to main menu");
            Console.ReadKey();
            menu.DisplaMainMenu();

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

            Console.ReadKey();
            menu.DisplaMainMenu();
            
        }

        //public void LogIn()
        //{
        //    Menu menu = new Menu();
        //    Console.WriteLine("Please, write your Email: ");
        //    string email = Console.ReadLine();

        //    Console.WriteLine("Please, write your Password: ");
        //    string password = Console.ReadLine();

        //    if ((email == Email) && (password == Password))
        //    {
        //        Console.WriteLine("Hello " + FirstName + " " + LastName! + " " + "Welcome back!");
        //        IsLoggedin = true;
        //    }
        //    else
        //    {
        //        Console.WriteLine("We are sorry. It seems like you provided wrong Username or Password.");
        //        IsLoggedin = false;
        //        Console.WriteLine("Please, press any key to go back to main menu.");
        //        Console.ReadKey();
        //        menu.DisplaMainMenu();
        //    }
        //}

        public void LogIn()
        {
            using (WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                Menu menu = new Menu();

                Console.WriteLine("Please, enter your Email.");
                string Email = Console.ReadLine();
                Console.WriteLine("Please. enter your password");
                string Password = Console.ReadLine();


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

                var customer = webshopDBContext.Customers.Find(choice).IsLoggedin = false;

                webshopDBContext.Orders.Add(order);

                webshopDBContext.SaveChanges();

                Console.WriteLine("Now you have logged out. Press enter to go back to main menu");
                menu.DisplaMainMenu();
            }
        }

        public void UpdateCustomer()
        {
            WebshopDBContext webshopDBContext = new WebshopDBContext();

            Console.WriteLine("Please, enter CustomerId.");
            var customerId = Convert.ToInt32(Console.ReadLine());
            var customer = webshopDBContext.Customers.Find(customerId);

            Console.WriteLine("Please, enter the new First Name for a customer. Current First Name is:" + " " + customer.FirstName);
            string FirstName2 = Console.ReadLine();
            Console.WriteLine("Please, enter the new Last Name for a customer. Current Last Name is:" + " " + customer.LastName);
            string LastName2 = Console.ReadLine();
            Console.WriteLine("Please, enter the new Email for a customer. Current Email is:" + " " + customer.Email);
            string Email2 = Console.ReadLine();
            Console.WriteLine("Please, enter the new Address for a customer. Current Address is:" + " " + customer.Address);
            string Address2 = Console.ReadLine();


            customer.FirstName = FirstName2;
            customer.LastName = LastName2;
            customer.Email = Email2;
            customer.Address = Address2;


            Console.WriteLine("Well done! The updated Customer has been added to the database! Press enter if you want to return to the main menu.");
            webshopDBContext.Update(customer);
            try
            {
                webshopDBContext.SaveChanges();

            }

            catch (DbUpdateConcurrencyException exception)
            {
                Console.WriteLine($"Something went wrong. Sorry. Try again later.{exception}"); //Save info about the error in the variable
            }

            Console.ReadKey();


        }

        public void DeleteCustomer()
        {
            WebshopDBContext webshopDBContext = new WebshopDBContext(); //Why do we need to create a new variable to represent the database?

            Console.WriteLine("Please, enter CustomerId.");
            var customerId = Convert.ToInt32(Console.ReadLine());
            var customer = webshopDBContext.Customers.Find(customerId); //Find always targeting PK

            try
            {

                webshopDBContext.Remove(customer);
                webshopDBContext.SaveChanges();
            }

            catch (DbUpdateConcurrencyException exception)
            {
                Console.WriteLine($"Something went wrong. Sorry. Try again later.{exception}");
            }

            Console.WriteLine("Oops, the Customer has been deleted now. Hope that's what you wanted :P. Press enter if you want to return to the main menu.");
            Console.ReadKey();


        }

        public void ReadCustomer()
        {

            WebshopDBContext webshopDBContext = new WebshopDBContext();

            Console.WriteLine("Please, enter CustomerId to find the right customer.");
            var customerId = Convert.ToInt32(Console.ReadLine());
            var customer = webshopDBContext.Customers.Find(customerId);

            if (customer == null)
            {

                Console.WriteLine("CustomerId was not found.");

            }

            if (customer != null)
            {
                Console.WriteLine("First Name is:" + " " + customer.FirstName);
                Console.WriteLine("Last Name is:" + " " + customer.LastName);
                Console.WriteLine("Email is:" + " " + customer.Email);
                Console.WriteLine("Address is:" + " " + customer.Address);
            }

            Console.ReadKey();
        }
    }
}


