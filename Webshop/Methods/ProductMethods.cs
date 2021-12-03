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
            CategoryMethods category = new CategoryMethods();
            WebshopDBContext _context = new WebshopDBContext();
            var productsFromDB = _context.Products.ToList();
            int userInput;

            if(testing)
            {
                userInput = 1;

            }else
            {
                Console.Clear();
                category.GetAllCategories();
                Console.WriteLine("\nPlease choose a category");
                userInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
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

        public void ResetAvailabilityWhenClosing()
        {
            using(WebshopDBContext webshopDBContext = new WebshopDBContext())
            {
                webshopDBContext.Products.Find(1).Availability = 10;
                webshopDBContext.Products.Find(2).Availability = 10;
                //webshopDBContext.Products.Find(3).Availability = 10;
                //webshopDBContext.Products.Find(4).Availability = 10;
                //webshopDBContext.Products.Find(5).Availability = 10;
                //webshopDBContext.Products.Find(6).Availability = 10;
                //webshopDBContext.Products.Find(7).Availability = 10;
                //webshopDBContext.Products.Find(8).Availability = 10;
                //webshopDBContext.Products.Find(9).Availability = 10;
                //webshopDBContext.Products.Find(10).Availability = 10;
                //webshopDBContext.Products.Find(11).Availability = 10;
                //webshopDBContext.Products.Find(12).Availability = 10;
                //webshopDBContext.Products.Find(13).Availability = 10;
                //webshopDBContext.Products.Find(14).Availability = 10;
                //webshopDBContext.Products.Find(15).Availability = 10;
                //webshopDBContext.Products.Find(16).Availability = 10;
                //webshopDBContext.Products.Find(17).Availability = 10; 
                //webshopDBContext.Products.Find(18).Availability = 10;
                //webshopDBContext.Products.Find(19).Availability = 10;
                //webshopDBContext.Products.Find(20).Availability = 10;
                //webshopDBContext.Products.Find(21).Availability = 10;
                //webshopDBContext.Products.Find(22).Availability = 10;
                //webshopDBContext.Products.Find(23).Availability = 10;
                //webshopDBContext.Products.Find(24).Availability = 10;
                //webshopDBContext.Products.Find(25).Availability = 10;

                webshopDBContext.SaveChanges();

            }
        }

    }
}
