using Loja.Ecommerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Ecommerce.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Insert(Product product);
        Task<Product> Update(Product product);
        Task<bool> Delete(Product product);
        Task<IEnumerable<Product>> GetAll(int skip = 0, int limit = 20);
        Task<IEnumerable<Product>> GetByName(string name, int skip = 0, int limit = 0);
        Task<IEnumerable<Product>> GetByCategory(string category, int skip = 0, int limit = 20);
        Task<Product> GetById(string id);
        Task<Product> GetBySku(string sku);
        Task<bool> HasExists(string sku);
    }
}
