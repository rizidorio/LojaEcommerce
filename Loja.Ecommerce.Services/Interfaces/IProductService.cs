﻿using Loja.Ecommerce.Services.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Ecommerce.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductModel> Insert(ProductModel productModel);
        Task<ProductModel> Update(ProductModel productModel);
        Task Delete(string id);
        Task<IEnumerable<ProductModel>> GetAll(int skip = 0, int limit = 20);
        Task<IEnumerable<ProductModel>> GetByName(string name, int skip = 0, int limit = 20);
        Task<IEnumerable<ProductModel>> GetByCategory(string category, int skip = 0, int limit = 20);
        Task<ProductModel> GetById(string id);
        Task<ProductModel> GetBySku(string sku);
    }
}
