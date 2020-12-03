using Loja.Ecommerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Ecommerce.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> Insert(Category category);
        Task<Category> Update(Category category);
        Task<bool> Delete(Category category);
        Task<IEnumerable<Category>> GetAll(int skip = 0, int limit = 10);
        Task<Category> GetById(string id);
        Task<Category> GetByName(string name);
        Task<bool> HasExists(string name);
    }
}
