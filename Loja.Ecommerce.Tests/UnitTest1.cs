using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Infra.Repository;
using Xunit;

namespace Loja.Ecommerce.Tests
{
    public class UnitTest1
    {
        //private readonly ProductRepository _repository;

        //public UnitTest1(ProductRepository repository)
        //{
        //    _repository = repository;
        //}

        ////Teste salvar
        //[Theory]
        //[InlineData("PROD0001", "Televisão 32 polegadas", "Televisão 32 polegadas", "Sony", "test image", , 526)]
        //[InlineData("PROD0002", "Geladeira 380 litros", "Geladeira 380 litros", "Eletrolux", "test image", "Geladeiras", 1250)]
        //[InlineData("PROD0003", "Fogão 4 bocas", "Fogão a gás 4 bocas", "Dako", "test image", "Fogês", 351)]
        //public void Save(string sku, string name, string description, string brand, string imageUrl, Category category, decimal price)
        //{
        //    Product product = new Product
        //    {
        //        SKU = sku,
        //        Name = name,
        //        Description = description,
        //        Brand = brand,
        //        ImageUrl = imageUrl,
        //        Category = category,
        //        Price = price
        //    };

        //    _repository.Save(product);
        //}

        //// Teste salvar null
        //[Theory]
        //[InlineData(null)]
        //public void SaveNull(Product product)
        //{
        //    Assert.Null(product);
        //}

        ////Teste SKU
        //[Theory]
        //[InlineData("PROD0003")]
        //public void SkuExist(string sku)
        //{
        //    Assert.True(_repository.HasExists(sku));
        //}

        ////Verifica Retorno
        //[Fact]
        //public void GetAll()
        //{
        //    Assert.NotEmpty(_repository.GetAll(0, 20));
        //}
    }
}
