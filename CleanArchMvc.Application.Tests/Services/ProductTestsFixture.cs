using Bogus;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Tests.Services
{
    [CollectionDefinition(nameof(ProductCollection))]
    public class ProductCollection : ICollectionFixture<ProductTestsFixture>
    { }
    public class ProductTestsFixture : IDisposable
    {
        public IEnumerable<ProductDTO> GenerateProducts()
        {          

            var productsFaker = new Faker<ProductDTO>()                 
                .RuleFor(p => p.Id, f => f.Random.Number(1, 50))
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()))
                .RuleFor(p => p.Stock, f => f.Random.Number())
                .RuleFor(p => p.Image, f => f.Image.PicsumUrl())            
                .RuleFor(p => p.CategoryId, f => f.Random.Number(1, 50));

            var products = productsFaker.Generate(50);

            return products;

        }       

        public void Dispose()
        {
        }
    }
}
