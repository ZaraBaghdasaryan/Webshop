using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webshop.Models;

namespace Webshop.Methods
{
    public class CategoryMethods
    {

        public IEnumerable<Category> GetAllCategories()
        {
            WebshopDBContext _context = new WebshopDBContext();

            var categoriesFromDB = _context.Categories.ToList();
            for (int i = 0; i < categoriesFromDB.Count; i++)
            {
                var categories = categoriesFromDB[i];
                Console.WriteLine($"Name: {categories.CategoryName}");
            }

            return (categoriesFromDB);
        }
    }
}
