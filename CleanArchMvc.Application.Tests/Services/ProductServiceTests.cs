using AutoMapper;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Application.Services;
using MediatR;
using Moq;

namespace CleanArchMvc.Application.Tests.Services
{
    [Collection(nameof(ProductCollection))]
    public class ProductServiceTests
    {
        readonly ProductTestsFixture _productTestsFixture;
        public ProductServiceTests(ProductTestsFixture productTestsFixture)
        {
            _productTestsFixture = productTestsFixture;
        }

        [Fact(DisplayName = "Return all products successfully")]
        [Trait("Category", "Product Service")]
        public async Task ProductService_GetProducts_ReturnAllProducts()
        {
            // Arrange
            var products = _productTestsFixture.GenerateProducts();
            var mapper = new Mock<IMapper>();
            var mediatr = new Mock<IMediator>();
            var productsResult = new ProductService(mapper.Object, mediatr.Object);
            // Act
            await productsResult.GetProducts();
            // Assert
            mediatr.Verify(x => x.Send(It.IsAny<GetProductsQuery>(), default), Times.Once);
            Assert.NotNull(products);
            Assert.True(products.Any());
        }

        [Fact(DisplayName = "Return Exception")]
        [Trait("Category", "Product Service")]
        public async Task ProductService_GetProducts_NullOrException()
        {
            // Arrange
            var mapper = new Mock<IMapper>();
            var mediatr = new Mock<IMediator>();

            var productService = new ProductService(mapper.Object, mediatr.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await productService.GetProducts());
        }

        [Fact(DisplayName = "Add Product")]
        [Trait("Category", "Product Service")]
        public async Task ProductService_Add_AddProduct()
        {
            // Arrange           
            var products = _productTestsFixture.GenerateProducts();
            var productDto = products.First();
            var mapper = new Mock<IMapper>();
            var mediatr = new Mock<IMediator>();
            var productsResult = new ProductService(mapper.Object, mediatr.Object);

            // Act            
            await productsResult.Add(productDto);

            // Assert
            mediatr.Verify(x => x.Send(It.IsAny<ProductCreateCommand>(), default), Times.Once);
            Assert.NotNull(products);
            Assert.True(products.Any());
        }

        [Fact(DisplayName = "Update Product")]
        [Trait("Category", "Product Service")]
        public async Task ProductService_Update_UpdateProduct()
        {
            // Arrange
            var products = _productTestsFixture.GenerateProducts();
            var productDto = products.First();
            var mapper = new Mock<IMapper>();
            var mediatr = new Mock<IMediator>();
            var productsResult = new ProductService(mapper.Object, mediatr.Object);

            // Act
            await productsResult.Update(productDto);

            // Assert
            mediatr.Verify(x => x.Send(It.IsAny<ProductUpdateCommand>(), default), Times.Once);
            Assert.NotNull(products);
            Assert.True(products.Any());
        }

        [Fact(DisplayName = "Remove Product")]
        [Trait("Category", "Product Service")]
        public async Task ProductService_Remove_RemoveProduct()
        {
            // Arrange
            var products = _productTestsFixture.GenerateProducts();
            var productId = 10;
            var product = products.FirstOrDefault(p => p.Id == productId);
            var mapper = new Mock<IMapper>();
            var mediatr = new Mock<IMediator>();
            var productsResult = new ProductService(mapper.Object, mediatr.Object);

            // Act
            await productsResult.Remove(product?.Id);

            // Assert            
            mediatr.Verify(x => x.Send(It.IsAny<ProductRemoveCommand>(), default), Times.Once);
            Assert.DoesNotContain(products.FirstOrDefault(p => p.Id == productId), products);
        }
    }
}
