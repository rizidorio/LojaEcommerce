using Loja.Ecommerce.Domain.Entities;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Loja.Ecommerce.Domain.Interfaces
{
    public interface IProductRepository
    {
        void Save(Product product);
        void Update(Product product);
        void Delete(ObjectId id);
        IEnumerable<Product> GetAll(int skip = 0, int limit = 20);
        Product GetById(ObjectId id);
        bool HasExists(string sku);
    }
}
