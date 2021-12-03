using System;
using Webshop.Methods;
using Xunit;
using Shouldly;
using webshop.models;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetAllProductsTest()
        {
            //Act
            var method = new ProductMethods();
            var result = method.GetAllProducts(true);

            //Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public void GetTotalPriceTest()
        {
            var method = new ShoppingCartMethods();
            var result = method.CalculateTotal(true);

            result.ShouldBe(699);
        }


        [Fact]
        public void Get()
        {
            var method = new ShoppingCartMethods();
            var result = method.CalculateTotal(true);

            result.ShouldBe(699);
        }
    }

    
}
