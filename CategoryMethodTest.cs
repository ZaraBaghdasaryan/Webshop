using Shouldly;
using Webshop.Methods;
using Xunit;

namespace Tests
{
    public class CategoryMethodTest
    {
        [Fact]
        public void GetAllProductsTest()
        {

            //Act
            var method = new CategoryMethods();
            var result = method.GetAllCategories();

            //Assert
            result.ShouldNotBeEmpty();
        }
    }
}

