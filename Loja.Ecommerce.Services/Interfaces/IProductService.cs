using Loja.Ecommerce.Services.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Ecommerce.Services.Interfaces
{
    public interface IProductService
    {
        Task Insert(ProductModel product);
        Task Update(ProductModel product);
        Task Delete(ObjectId id);
        Task<IEnumerable<ProductModel>> GetAll(int skip = 0, int limit = 20);
        Task<IEnumerable<ProductModel>> GetByCategory(string category, int skip = 0, int limit = 20);
        Task<ProductModel> GetById(ObjectId id);
        Task<ProductModel> GetBySku(string sku);
    }
}
