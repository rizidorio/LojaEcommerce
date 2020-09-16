using Loja.Ecommerce.Services.Models;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Loja.Ecommerce.Services.Interfaces
{
    public interface ICategoryService
    {
        void Insert(CategoryModel category);
        void Update(CategoryModel category);
        void Delete(ObjectId id);
        IEnumerable<CategoryModel> GetAll(int skip = 0, int limit = 10);
        CategoryModel GetById(ObjectId id);
    }
}
