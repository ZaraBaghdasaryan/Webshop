using System;
using System.Collections.Generic;
using System.Linq;
using Webshop.Models;
using Xunit;

namespace UnitTests
{
    public class UnitTests
    { 
        [Fact]
        public void GetOneCategory()
        {
            //Arrange
            var category = new List<Category>();
            category.Add(new Category { CategoryId = 1});

            //Act
            //var foundCategory = new Category(true);
            //var result = foundCategory.GetAllCategories(category, true);

            //Assert
           // result.NotNull();
           
        }

        [Fact]
        public void GetProductQuantity()
        {

            //Arrange
            List<Product> products = new List<Product>();
            products.Add(new Product { ProductId = 1 });

            //Act
            var method = new Product(true);
           // var result = method.GetAllProducts(products, true);

            //Assert
          //  result.ProductId.ShouldBe(products.First().ProductId);
        }
    }
}

