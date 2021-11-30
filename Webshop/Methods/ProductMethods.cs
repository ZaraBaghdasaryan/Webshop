using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webshop.Models;

namespace Webshop.Methods
{
    public class ProductMethods
    {

        public IEnumerable<Product> GetAllProducts( bool testing)
        {
            Menu menu = new Menu();
            WebshopDBContext _context = new WebshopDBContext();
            var productsFromDB = _context.Products.ToList();
            int userInput;

            if(testing)
            {
                userInput = 1;
            }else
            {
                Console.WriteLine("Please choose a category");
                userInput = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < productsFromDB.Count; i++)
            {
                
                var products = productsFromDB[i];
                if (userInput == products.CategoryId)
                {
                    Console.WriteLine($"\n Id: {products.ProductId} \n Name: {products.ProductName} \n Price: {products.Price}.- \n Number of items available for puchase: {products.Availability}pcs");

                }

            }

            return (productsFromDB);
        }
    }
}
