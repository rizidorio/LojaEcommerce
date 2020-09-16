using Loja.Ecommerce.Domain.Entities;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Loja.Ecommerce.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        void Save(Category category);
        void Update(Category category);
        void Delete(ObjectId id);
        IEnumerable<Category> GetAll(int skip = 0, int limit = 10);
        Category GetById(ObjectId id);
        bool HasExists(string name);
    }
}
