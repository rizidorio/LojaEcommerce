using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Services.Models;
using Loja.Ecommerce.Services.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Loja.Ecommerce.Tests
{
    public class CategoryTests
    {
        private readonly CategoryService _service;
        private readonly Mock<ICategoryRepository> _categoryMockRepository = new Mock<ICategoryRepository>();

        public CategoryTests()
        {
            _service = new CategoryService(_categoryMockRepository.Object);
        }

        [Fact]
        public async Task GetCategoryByName_Success()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var categoryName = "Categoria Teste";
            var categoryTest = new Category(customerId, categoryName);
            
            _categoryMockRepository.Setup(x => x.GetByName(categoryName.ToUpper())).ReturnsAsync(categoryTest);

            // Act
            var category = await _service.GetByName(categoryName);

            // Assert
            Assert.Equal(categoryName.ToUpper(), category.Name.ToUpper());
        }

        [Fact]
        public async Task GetCategoryByName_Test_NotName_Exceptior()
        {
            // Arrange
            _categoryMockRepository.Setup(x => x.GetByName(It.IsAny<string>())).ReturnsAsync(() => null);

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.GetByName(""));

            // Assert
            Assert.Equal("O nome não pode ser em branco.", exception.Message);
        }

        [Fact]
        public async Task InsertCategory_Test_Success()
        {
            // Arrange
            var categoryTest = new Category(null, "Categoria Teste");

            _categoryMockRepository.Setup(x => x.Insert(categoryTest)).ReturnsAsync(categoryTest);

            CategoryModel categoryModelTest = new CategoryModel
            {
                Id = categoryTest.Id.ToString(),
                Name = categoryTest.Name
            };

            // Act
            var category = await _service.Insert(categoryModelTest);

            // Assert
            Assert.Equal(categoryTest.Id.ToString(), category.Id);
            Assert.Equal(categoryTest.Name, category.Name);
        }
    }
}
