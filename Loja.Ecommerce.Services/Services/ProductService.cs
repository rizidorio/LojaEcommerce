using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Models;
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

        public async Task<ProductModel> Insert(ProductModel productModel)
        {
            if (await _productRepository.HasExists(productModel.SKU.ToUpper()))
                throw new Exception("Produto já cadastrado.");

            var category = await _categoryRepository.GetByName(productModel.Category.ToUpper());

            var convertedProduct = new Product(null, productModel.SKU, productModel.Name, productModel.Description, 
                                               productModel.Brand, productModel.ImageUrl, category, productModel.Price);

            var result = await _productRepository.Insert(convertedProduct);

            if(result != null)
            {
                productModel.Id = result.Id.ToString();   
            }
            return productModel;
        }        

        public async Task<ProductModel> Update(ProductModel productModel)
        {
            var queriedProduct = await _productRepository.GetById(productModel.Id);

            if (queriedProduct == null)
                throw new Exception("Produto não encontrado.");

            var category = await _categoryRepository.GetByName(productModel.Category.ToUpper());

            var convertedProduct = new Product(Guid.Parse(productModel.Id), productModel.SKU, productModel.Name, productModel.Description, 
                                                productModel.Brand, productModel.ImageUrl, category, productModel.Price);

            var result = await _productRepository.Update(convertedProduct);

            if (result != null)
            {
                productModel.Id = result.Id.ToString();
                productModel.SKU = result.SKU;
                productModel.Name = result.Name;
                productModel.Description = result.Description;
                productModel.Brand = result.Brand;
                productModel.ImageUrl = result.ImageUrl;
                productModel.Price = result.Price;                
            }

            return productModel;
        }

        public async Task Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("O Id não pode ser em branco.");

            var productExist = await _productRepository.GetById(id);

            if (productExist != null)
                await _productRepository.Delete(productExist);
            else
                throw new Exception("Categoria não encontrada");
        }

        public async Task<IEnumerable<ProductModel>> GetAll(int skip = 0, int limit = 20)
        {
            var result = await _productRepository.GetAll(skip, limit);

            if (result.Count() == 0)
                throw new Exception("Não existe produtos cadastrados.");

            return result.Select(product => new ProductModel
            {
                Id = product.Id.ToString(),
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Category = product.Category.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            });
        }

        public async Task<IEnumerable<ProductModel>> GetByCategory(string category, int skip = 0, int limit = 20)
        {
            var result = await _productRepository.GetByCategory(category.ToUpper(), skip, limit);

            if (result.Count() == 0)
                throw new Exception("Não existe produtos nessa categoria.");

            return result.Select(product => new ProductModel
            {
                Id = product.Id.ToString(),
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Category = product.Category.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            });
        }

        public async Task<ProductModel> GetBySku(string sku)
        {
            var product = await _productRepository.GetBySku(sku.ToUpper());

            if (product == null)
                throw new Exception("Produto não encontrado.");

            return new ProductModel
            {
                Id = product.Id.ToString(),
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Category = product.Category.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };
        }

        public async Task<IEnumerable<ProductModel>> GetByName(string name, int skip = 0, int limit = 20)
        {
            var result = await _productRepository.GetByName(name, skip, limit);

            if (result.Count() == 0)
                throw new Exception("Produto não econtrado.");

            return result.Select(product => new ProductModel
            {
                Id = product.Id.ToString(),
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Category = product.Category.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            });
        }

        public async Task<ProductModel> GetById(string id)
        {
            if (id == null)
                throw new Exception("O Id não pode ser em branco.");

            var product = await _productRepository.GetById(id);

            if (product == null)
            {
                throw new Exception("Produto não encontrado.");
            }
                
            return new ProductModel
            {
                Id = product.Id.ToString(),
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Brand = product.Brand,
                Category = product.Category.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };
        }
    }
}
