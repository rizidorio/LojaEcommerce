using Loja.Ecommerce.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Ecommerce.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Insert(CategoryModel category);
        Task Update(CategoryModel category);
        Task Delete(string id);
        Task<IEnumerable<CategoryModel>> GetAll(int skip = 0, int limit = 10);
        Task<CategoryModel> GetById(string id);
        Task<CategoryModel> GetByName(string name);
    }
}
