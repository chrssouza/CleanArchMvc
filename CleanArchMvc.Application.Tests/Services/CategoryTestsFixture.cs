using Bogus;
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Tests.Services
{
    [CollectionDefinition(nameof(CategoryCollection))]
    public class CategoryCollection : ICollectionFixture<CategoryTestsFixture>
    { }
    public class CategoryTestsFixture : IDisposable
    {
        public IEnumerable<CategoryDTO> GenerateCategory()
        {
            var categoriesFaker = new Faker<CategoryDTO>()
                .RuleFor(p => p.Id, f => f.Random.Number(1, 10))
                .RuleFor(p => p.Name, f => f.Commerce.ToString());

            var categories = categoriesFaker.Generate(10);

            return categories;
        }


        public void Dispose()
        {            
        }
    }
}
