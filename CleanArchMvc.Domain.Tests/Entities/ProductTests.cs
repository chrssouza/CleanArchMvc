//using CleanArchMvc.Domain.Entities;
//using Moq.AutoMock;
//using System.Reflection;
//using Xunit;

//namespace CleanArchMvc.Domain.Tests.Entities
//{
//    [Collection(nameof(ProductCollection))]
//    public class ProductTests
//    {

//        readonly ProductTestsFixture _productTestsFixture;
//        public ProductTests(ProductTestsFixture productTestsFixture)
//        {
//            _productTestsFixture = productTestsFixture;
//        }

//        [Theory]
//        [InlineData("Book", "book of horror stories", 10, 5, "image.jpg")]
//        [Trait("Category", "Product Automock Tests")]
//        public void Product_ValidateDomain_MustValidade(string name, string description, decimal price, int stock, string image)
//        {
//            // Arrange
//            var products = _productTestsFixture.GenerateValidProducts();
//            var mocker = new AutoMocker();
//            var validadeDomain = mocker.CreateInstance<Product>();

//            // Act
//            validadeDomain.ValidateDomain(name, description, price, stock, image);
//            // Assert

//        }

//        [Theory]
//        [InlineData("Book", "book of horror stories", 10, 5, "image.jpg", 1)]
//        [Trait("Category", "Product Automock Tests")]
//        public void Product_Update_Success(string name, string description, decimal price, int stock, string image, int categoryId)
//        {
//            // Arrange
//            var products = _productTestsFixture.GenerateValidProducts();
//            var mocker = new AutoMocker();
//            var validadeDomain = mocker.CreateInstance<Product>();

//            // Act
//            validadeDomain.ValidateDomain(name, description, price, stock, image);
//            MethodInfo
//            // Assert
//        }
//    }
//}
