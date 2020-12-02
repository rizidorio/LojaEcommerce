using Loja.Ecommerce.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Ecommerce.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryModel> Insert(CategoryModel categoryModel);
        Task<CategoryModel> Update(CategoryModel categoryModel);
        Task Delete(string id);
        Task<IEnumerable<CategoryModel>> GetAll(int skip = 0, int limit = 10);
        Task<CategoryModel> GetById(string id);
        Task<CategoryModel> GetByName(string name);
    }
}
