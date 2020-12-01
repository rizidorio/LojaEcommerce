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
    public class ProductTests
    {
        private readonly ProductService _service;
        private readonly Mock<IProductRepository> _productMockRepository = new Mock<IProductRepository>();
        private readonly Mock<ICategoryRepository> _categoryMockRepository = new Mock<ICategoryRepository>();

        public ProductTests()
        {
            _service = new ProductService(_productMockRepository.Object, _categoryMockRepository.Object);
        }

        [Fact]
        public async Task GetProductByIdTest()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var productSKU = "PROD0001";
            var category = new Category(null, "Categoria Teste");
            var productTest = new Product(customerId, productSKU, "Produto Teste", "Produto Teste", "Marca Teste", "Imagem teste", category, 125);
            
            _productMockRepository.Setup(x => x.GetById(customerId.ToString())).ReturnsAsync(productTest);

            // Act
            var product = await _service.GetById(customerId.ToString());

            // Assert
            Assert.Equal(customerId.ToString(), product.Id);
            Assert.Equal(productSKU, product.SKU);
        }

        [Fact]
        public async Task GetProductByIdNotExistsTest()
        {
            // Arrange
           _productMockRepository.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(() => null);

            // Act
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.GetById(Guid.NewGuid().ToString()));

            // Assert
            Assert.Equal("Produto não encontrado.", exception.Message);
        }

        [Fact]
        public async Task InsertProduct()
        {
            // Arrange
            var category = new Category(null, "Categoria Teste");

            var productTest = new Product(null, "PROD0001", "Produto Teste", "Produto Teste", "Marca Teste", "Imagem teste", category, 125);

            _productMockRepository.Setup(x => x.Insert(productTest)).ReturnsAsync(productTest);

            ProductModel productModelTest = new ProductModel
            {
                Id = productTest.Id.ToString(),
                SKU = productTest.SKU,
                Name = productTest.Name,
                Description = productTest.Description,
                Brand = productTest.Brand,
                ImageUrl = productTest.ImageUrl,
                Category = productTest.Category.Name,
                Price = productTest.Price
            };

            // Act
            var product = await _service.Insert(productModelTest);

            // Assert
            Assert.Equal(productTest.Id.ToString(), product.Id);
            Assert.Equal(productTest.Name, product.Name);
        }
    }
}
