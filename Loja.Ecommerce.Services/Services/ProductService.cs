using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<ProductModel>> GetAll(int skip = 0, int limit = 20)
        {
            var result = await _productRepository.GetAll(skip, limit);

            if (result.Count() == 0)
                throw new Exception("Não existe produtos cadastrados.");

            return result.Select(prod => new ProductModel
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

        public async Task<IEnumerable<ProductModel>> GetByCategory(string category, int skip = 0, int limit = 20)
        {
            var result = await _productRepository.GetByCategory(category.ToUpper(), skip, limit);

            if (result.Count() == 0)
                throw new Exception("Não existe produtos nessa categoria.");

            return result.Select(prod => new ProductModel
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

        public async Task<ProductModel> GetById(ObjectId id)
        {
            if (id == null)
                throw new Exception("O Id não pode ser em branco.");

            var prod = await _productRepository.GetById(id);

            if (prod == null)
                throw new Exception("Produto não encontrado.");

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

        public async Task<ProductModel> GetBySku(string sku)
        {
            var prod = await _productRepository.GetBySku(sku.ToUpper());

            if(prod == null)
                throw new Exception("Produto não encontrado.");

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

        public async Task Insert(ProductModel product)
        {
            if(await _productRepository.HasExists(product.SKU.ToUpper()))
                throw new Exception("Produto já cadastrado.");

            var cat = await _categoryRepository.GetByName(product.Category.ToUpper());

            if(cat == null)
                throw new Exception("Categoria inválida.");

            var prod = new Product
            {
                SKU = product.SKU.ToUpper(),
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Category = cat,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };

            if (string.IsNullOrEmpty(prod.Name))
                throw new Exception("O nome do produto não pode ser em branco.");

            if (string.IsNullOrEmpty(prod.SKU))
                throw new Exception("O SKU do produto não pode ser em branco.");

            if (string.IsNullOrEmpty(prod.Brand))
                throw new Exception("A marca do produto não pode ser em branco.");

            if (prod.Price <= 0)
                throw new Exception("O preço do produto não pode ser menor ou igual a 0.");

            await _productRepository.Insert(prod);
        }

        public async Task Update(ProductModel product)
        {
            var convertedId = ObjectId.Parse(product.Id);

            var queriedProduct = await _productRepository.GetById(convertedId);

            if (queriedProduct == null)
                throw new Exception("Produto não encontrado.");

            var cat = await _categoryRepository.GetByName(product.Category.ToUpper());

            var prod = new Product
            {
                Id = convertedId,
                SKU = product.SKU.ToUpper(),
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Category = cat,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };

            if (string.IsNullOrEmpty(prod.Name))
                throw new Exception("O nome do produto não pode ser em branco.");

            if (string.IsNullOrEmpty(prod.SKU))
                throw new Exception("O SKU do produto não pode ser em branco.");

            if (string.IsNullOrEmpty(prod.Brand))
                throw new Exception("A marca do produto não pode ser em branco.");

            if (prod.Price <= 0)
                throw new Exception("O preço do produto não pode ser menor ou igual a 0.");

            await _productRepository.Update(prod);
        }

        public async Task Delete(ObjectId id)
        {
            if (id == null)
                throw new Exception("O Id não pode ser em branco.");

            await _productRepository.Delete(id);
        }
    }
}
