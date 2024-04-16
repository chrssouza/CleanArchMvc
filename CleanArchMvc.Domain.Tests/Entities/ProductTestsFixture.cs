using Bogus;
using Bogus.DataSets;
using CleanArchMvc.Domain.Entities;
using Xunit;

namespace CleanArchMvc.Domain.Tests.Entities
{
    [CollectionDefinition(nameof(ProductCollection))]
    public class ProductCollection : ICollectionFixture<ProductTestsFixture> 
    { }
    public class ProductTestsFixture : IDisposable
    {
        public IEnumerable<Product> GenerateProducts()
        {
            var id = 1;
            //var productName = new Faker().PickRandom<Commerce>();

            var productsFaker = new Faker<Product>()
                .RuleFor(p => p.Id, f => id++)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()))
                .RuleFor(p => p.Stock, f => f.Random.Number())
                .RuleFor(p => p.Image, f => f.Image.PicsumUrl());
            //.CustomInstantiator(p => new Product(
            //     Guid.NewGuid(),
            //     p.Commerce.ProductName,
            //     p.Commerce.ProductDescription,
            //     p.Commerce.Price(),

            var products = productsFaker.Generate(1000);

            return products;
                   
        }

        public IEnumerable<Product> GenerateValidProducts()
        {
            var validProducts = GenerateProducts();
            var filteredProducts = validProducts.Where(p => p.Name.Length >= 3 && 
            p.Description.Length >= 5 && 
            p.Price > 0 && 
            p.Stock > 0 && 
            p.Image.Length > 250);

            return filteredProducts;
        }

        public IEnumerable<Product> GenerateInvalidProducts()
        {
            var validProducts = GenerateValidProducts();

            if (!validProducts.Any()) // Se não houver produtos válidos, retorna false
            {
                return Enumerable.Empty<Product>(); // Retorna uma lista vazia de produtos inválidos
            }
            return validProducts;
        }


        public void Dispose()
        {
        }
    }
}
