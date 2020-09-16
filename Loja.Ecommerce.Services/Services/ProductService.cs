using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loja.Ecommerce.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<ProductModel> GetAll(int skip = 0, int limit = 20)
        {
            return _productRepository.GetAll(skip, limit).Select(prod => new ProductModel
            {
                Id = prod.Id.ToString(),
                SKU = prod.SKU,
                Name = prod.Name,
                Description = prod.Description,
                Brand = prod.Brand,
                Category = prod.Category.Name,    
                ImageUrl = prod.ImageUrl,
                Price = prod.Price
            });
        }

        public ProductModel GetById(ObjectId id)
        {
            if (id == null)
                throw new Exception("O Id não pode ser em branco.");

            var prod = _productRepository.GetById(id);

            return new ProductModel
            {
                Id = prod.Id.ToString(),
                SKU = prod.SKU,
                Name = prod.Name,
                Description = prod.Description,
                Brand = prod.Brand,
                Category = prod.Category.Name,
                ImageUrl = prod.ImageUrl,
                Price = prod.Price
            };
        }

        public void Insert(ProductModel product)
        {
            if (_productRepository.HasExists(product.SKU))
                throw new Exception("SKU já existe.");

            var cat = _categoryRepository.GetById(ObjectId.Parse(product.Category));

            var prod = new Product
            {
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Category = cat,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };

            _productRepository.Save(prod);
        }

        public void Update(ProductModel product)
        {
            var convertedId = ObjectId.Parse(product.Id);

            var queriedProduct = _productRepository.GetById(convertedId);

            if (queriedProduct == null)
                throw new Exception("Produto não encontrado.");

            var cat = _categoryRepository.GetById(ObjectId.Parse(product.Category));

            var prod = new Product
            {
                Id = convertedId,
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Category = cat,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };

            _productRepository.Update(prod);
        }

        public void Delete(ObjectId id)
        {
            if (id == null)
                throw new Exception("O Id não pode ser em branco.");

            _productRepository.Delete(id);
        }
    }
}
