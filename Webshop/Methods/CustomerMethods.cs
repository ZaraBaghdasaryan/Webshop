
using System;
using Microsoft.EntityFrameworkCore;

namespace Webshop.methods
{
    public class customermethods
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsLoggedin { get; set; }

        public void SignUp()

        //{
        //    webshopdbcontext webshopdbcontext = new webshopdbcontext();
        //    menu menu = new menu();

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

            if (Address == "back")
            {
                menu.DisplayLoginSignUpMenu();
            }

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

                if(Password == "back")
                {
                    menu.DisplayLoginSignUpMenu();
                }

        //        //string lookforemail = webshopdbcontext.customers
        //        //    .where(c => c.email == email).firstordefault().email;
        //        //string lookforpassword = webshopdbcontext.customers
        //        //    .where(c => c.password == password).firstordefault().password;

        //        //if (lookforemail.equals(email) && lookforpassword.equals(password))
        //        //{

        //        //    var customer = webshopdbcontext.customers
        //        //        .where(c => c.email == email)
        //        //        .firstordefault();

        //        //    customer.isloggedin = true;


                    Console.WriteLine($"Welcome {customer.FirstName}, you are now logged in!");
                    webshopDBContext.Customers.Update(customer);
                    webshopDBContext.SaveChanges();
                    Console.ReadKey();
                    menu.DisplayLoginSignUpMenu();
                }

        //    }
        //}


            public void LogOut()

        {
            Menu menu = new Menu();
            Order order = new Order();

        //    using (webshopdbcontext webshopdbcontext = new webshopdbcontext())
        //    {
        //        console.writeline("to log out press 1");
        //        var choice = convert.toint32(console.readline());

                var customer = webshopDBContext.Customers.Find(choice).IsLoggedin = false;

                webshopDBContext.Orders.Add(order);

                webshopDBContext.SaveChanges();

                Console.WriteLine("Now you have logged out. Press enter to go back to main menu");
                menu.DisplaMainMenu();
            }
        }

        public void UpdateCustomer()
        {
            WebshopDBContext webshopdbcontext = new WebshopDBContext();

            Console.WriteLine("please, enter customerid.");
            var customerid = Convert.ToInt32(Console.ReadLine());
            var customer = webshopdbcontext.Customers.Find(customerid);

            Console.WriteLine("please, enter the new first name for a customer. current first name is:" + " " + customer.FirstName);
            string firstname2 = Console.ReadLine();
            Console.WriteLine("please, enter the new last name for a customer. current last name is:" + " " + customer.LastName);
            string lastname2 = Console.ReadLine();
            Console.WriteLine("please, enter the new email for a customer. current email is:" + " " + customer.Email);
            string email2 = Console.ReadLine();
            Console.WriteLine("please, enter the new address for a customer. current address is:" + " " + customer.Address);
            string address2 = Console.ReadLine();


            customer.FirstName = firstname2;
            customer.LastName = lastname2;
            customer.Email = email2;
            customer.Address = address2;


            Console.WriteLine("well done! the updated customer has been added to the database! press enter if you want to return to the main menu.");
            webshopdbcontext.Update(customer);
            try
            {
                webshopdbcontext.SaveChanges();

            }

            catch (DbUpdateConcurrencyException exception)
            {
                Console.WriteLine($"something went wrong. sorry. try again later.{exception}"); //save info about the error in the variable
            }

            Console.ReadKey();


        }

        public void deletecustomer()
        {
            WebshopDBContext webshopdbcontext = new WebshopDBContext(); //why do we need to create a new variable to represent the database?

            Console.WriteLine("please, enter customerid.");
            var customerid = Convert.ToInt32(Console.ReadLine());
            var customer = webshopdbcontext.Customers.Find(customerid); //find always targeting pk

            try
            {

                webshopdbcontext.Remove(customer);
                webshopdbcontext.SaveChanges();
            }

            catch (DbUpdateConcurrencyException exception)
            {
                Console.WriteLine($"something went wrong. sorry. try again later.{exception}");
            }

            Console.WriteLine("oops, the customer has been deleted now. hope that's what you wanted :p. press enter if you want to return to the main menu.");
            Console.ReadKey();


        }

        public void readcustomer()
        {

            WebshopDBContext webshopdbcontext = new WebshopDBContext();

            Console.WriteLine("please, enter customerid to find the right customer.");
            var customerid = Convert.ToInt32(Console.ReadLine());
            var customer = webshopdbcontext.Customers.Find(customerid);

            if (customer == null)
            {

                Console.WriteLine("customerid was not found.");

            }

            if (customer != null)
            {
                Console.WriteLine("first name is:" + " " + customer.FirstName);
                Console.WriteLine("last name is:" + " " + customer.LastName);
                Console.WriteLine("email is:" + " " + customer.Email);
                Console.WriteLine("address is:" + " " + customer.Address);
            }

            Console.ReadKey();
        }
    }
}


