using System;
using System.Collections.Generic;
using System.Linq;
using webshop;
using webshop.models;
using Webshop;
using Webshop.Models;

namespace webshop.models
{
    public class ShoppingCartMethods
    {
        Menu menu = new Menu();
        public List<Product> Cartlist = new List<Product>();

        public void AddToShoppingCart()
        {
            Cartlist.Add(new Product(false));
            Console.WriteLine("you have just added the product/products to your shopping cart!");
            Console.WriteLine("press any key to continue shopping.");
            Console.ReadKey();
            menu.DisplaMainMenu();
        }

        public void RemoveFromShoppingCart()
        {
            {
                var last = Cartlist.Count() - 1;
                Cartlist.RemoveAll(r => Cartlist[last].ProductId == r.ProductId);
            }
            Console.WriteLine("The shopping cart has been emptied.");
            Console.WriteLine("Press any key to continue shopping.");
            Console.WriteLine();
            menu.DisplaMainMenu();
        }

        public void PrintCart(List<Product> Cartlist)
        {
            Console.Clear();
            for (int i = 0; i < Cartlist.Count; i++)
            {
                Console.WriteLine(Cartlist[i].PrintProducts());
            }
            double total = 0;
            for (int i = 0; i < Cartlist.Count; i++)
            {
                total = total + Cartlist[i].Price;

            }
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine($"\nshopping cart total: {total}:-");
            Console.WriteLine("\n-----------------------------");

            Console.WriteLine("\n1. checkout");
            Console.WriteLine("\n2. empty cart");
            Console.WriteLine("\n3. go back");
            var input = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                if (input == 1)
                {
                    Checkout();
                    break;
                }
                else if (input == 2)
                {
                    RemoveFromShoppingCart();
                    break;
                }
                else if (input == 3)
                {
                    //go back
                    menu.DisplaMainMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("Please, type in only numbers.");
                }
            }
        }

        public void Checkout()
        {
            Order neworder = new Order(Cartlist); //Customer.Address, Customer.FirstName can't be used unless static, but that creates a conflict in the Sign Up method
            neworder.PrintReciept();
            Console.WriteLine("Press any key to continue shopping.");
            Console.ReadKey();
            menu.DisplaMainMenu();
            Cartlist.Clear();
        }
    }
}
