using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [MaxLength(150), Required]
        public string Email { get; set; }

        [MaxLength(20), Required]
        public string Password { get; set; }

        public bool IsLoggedin { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        public List<Order> Orders { get; set; }



        public void SignUp()

        {
            WebshopDBContext webshopDBContext = new WebshopDBContext();
            Menu menu = new Menu();

            Console.WriteLine("Please, enter your first name.");
            string FirstName = Console.ReadLine().ToLower();

            if (FirstName == "back")
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



            Console.WriteLine("Welcome" + " " + FirstName + " " + LastName + " to our exciting store!");
            Console.WriteLine("Here is your account information:" + " " + "Username:" + " " + Email + " " + "Name:" + " " + FirstName + " " + LastName + " Adress: " + Address);

            Console.WriteLine("Please, press any key to go back to main menu");
            Console.ReadKey();
            menu.DisplaMainMenu();

            webshopDBContext.Customers.Add(customer);
            webshopDBContext.SaveChanges();


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

                Console.WriteLine("Please. enter your password");
                string Password = Console.ReadLine().ToLower();

                if (Password == "back")
                {
                    menu.DisplayLoginSignUpMenu();
                }

                Console.WriteLine("Write email");
                string email = Console.ReadLine().ToLower(); 

                Console.WriteLine("Write password");
                string password = Console.ReadLine().ToLower(); 

                if ((email == Email) && (password == Password))
                {
                    Console.WriteLine("Login successful!");
                    Console.WriteLine("Please, press any key to go back to main menu");
                    Console.ReadKey();
                    menu.DisplaMainMenu();
                }

                else

                {
                    Console.WriteLine("Oops");
                    Console.WriteLine("Please, press any key to go back to main menu");
                    Console.ReadKey();
                    menu.DisplaMainMenu();
                }
            }
        }

        //LogIn Alternative 
        //public void login()
        //{
        //    using (WebshopDBContext webshopdbcontext = new WebshopDBContext())
        //    {
        //        Console.WriteLine("write >back< if you want to go back");
        //        Menu menu = new Menu();

        //        Console.WriteLine("please, enter your email.");
        //        string email = Console.ReadLine().ToLower();

        //        if (email == "back")
        //        {
        //            menu.DisplayLoginSignUpMenu();
        //        }

        //        Console.WriteLine("please. enter your password");
        //        string password = Console.ReadLine().ToLower();

        //        if (password == "back")
        //        {
        //            menu.DisplayLoginSignUpMenu();
        //        }

        //        string lookforemail = webshopdbcontext.Customers
        //            .Where(c => c.Email == email).FirstOrDefault().Email;
        //        string lookforpassword = webshopdbcontext.Customers
        //            .Where(c => c.Password == password).FirstOrDefault().Password;

        //        if (lookforemail.Equals(email) && lookforpassword.Equals(password))
        //        {

        //            var customer = webshopdbcontext.Customers
        //                .Where(c => c.Email == email)
        //                .FirstOrDefault();

        //            customer.IsLoggedin = true;


        //            Console.WriteLine($"welcome {customer.FirstName}, you are now logged in!");
        //            webshopdbcontext.Customers.Update(customer);
        //            webshopdbcontext.SaveChanges();
        //            Console.ReadKey();
        //            menu.DisplayLoginSignUpMenu();
        //        }
        //        else
        //        {
        //            Console.WriteLine("no user matching those credentials were found. please try again");
        //            login();
        //        }

        //    }
        //}

        public void LogOut()
        {
            Menu menu = new Menu();
            Order order = new Order();

            using (WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                Console.WriteLine("To log out press enter");
                //var choice = Convert.ToInt32(Console.ReadLine());

                Console.ReadKey();
                Console.WriteLine("Now you have logged out. Press any key to go back to the login menu");
                Console.ReadKey();
                menu.DisplayLoginSignUpMenu();

                var customer = webshopDBContext.Customers.Where(c => c.IsLoggedin == true).FirstOrDefault().IsLoggedin = false;
                webshopDBContext.SaveChanges(customer);
            }
        }
    }
}