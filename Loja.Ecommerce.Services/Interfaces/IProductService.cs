using Loja.Ecommerce.Services.Models;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Loja.Ecommerce.Services.Interfaces
{
    public interface IProductService
    {
        void Insert(ProductModel product);
        void Update(ProductModel product);
        void Delete(ObjectId id);
        IEnumerable<ProductModel> GetAll(int skip = 0, int limit = 20);
        ProductModel GetById(ObjectId id);
    }
}
