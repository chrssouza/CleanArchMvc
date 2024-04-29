using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using Moq;

namespace CleanArchMvc.Application.Tests.Services
{
    [Collection(nameof(CategoryCollection))]
    public class CategoryServiceTests
    {
        readonly CategoryTestsFixture _categoryTestsFixture;
        public CategoryServiceTests(CategoryTestsFixture categoryTestsFixture)
        {

            _categoryTestsFixture = categoryTestsFixture;

        }

        [Fact(DisplayName = "Return all gategory successfully")]
        [Trait("Category", "Category Service")]
        public async Task CategoryService_GetCategories_ReturnAllCategories()
        {
            // Arrange
            var mapper = new Mock<IMapper>();
            var categoryRepository = new Mock<ICategoryRepository>();
            var categoryResult = new CategoryService(mapper.Object, categoryRepository.Object);

            // Act
            var result = await categoryResult.GetCategories();

            // Assert
            categoryRepository.Verify(x => x.GetCategories(), Times.Once());
            Assert.NotNull(result);
        }

        [Theory(DisplayName = "Return category by id")]
        [InlineData(1)]
        [InlineData(2)]
        [Trait("Category", "Category Service")]
        public async Task CategoryService_GetById_ReturnCategoryById(int? id)
        {
            // Arrange
            var mapper = new Mock<IMapper>();
            var categoryRepository = new Mock<ICategoryRepository>();
            var categoryResult = new CategoryService(mapper.Object, categoryRepository.Object);
            // Act
            var result = await categoryResult.GetById(id);

            // Assert

            categoryRepository.Verify(x => x.GetById(id), Times.Once());
            Assert.Equal(1, result.Id);
            Assert.IsType<CategoryDTO>(result);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Add a category")]
        [Trait("Category", "Category Service")]
        public async Task CategoryService_Add_MustAddACategory()
        {
            // Arrange
            var category = _categoryTestsFixture.GenerateCategory();
            var firstProduct = category.First();
            var mapper = new Mock<IMapper>();
            var categoryRepository = new Mock<ICategoryRepository>();
            var categoryResult = new CategoryService(mapper.Object, categoryRepository.Object);

            // Act
            await categoryResult.Add(firstProduct);

            // Assert
            categoryRepository.Verify(x => x.Create(It.IsAny<Category>()), Times.Once());
            Assert.NotNull(category);

        }
    }
}

