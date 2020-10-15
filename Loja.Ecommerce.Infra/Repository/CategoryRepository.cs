using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Infra.Context;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Ecommerce.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ContextMongo _context;

        public CategoryRepository(ContextMongo context)
        {
            _context = context;
        }

        public async Task<Category> Insert(Category category)
        {
            await _context.Category.InsertOneAsync(category);
            return category;
        }

        public async Task Update(Category category)
        {
            await _context.Category.ReplaceOneAsync(c => c.Id.Equals(category.Id), category);  
        }

        public async Task Delete(string id)
        {
           await _context.Category.DeleteOneAsync(c => c.Id.Equals(id));
        }

        public async Task<IEnumerable<Category>> GetAll(int skip, int limit)
        {
            return await _context.Category.Find(c => true).Skip(skip).Limit(limit).ToListAsync();
        }

        public async Task<Category> GetById(string id)
        {
            return await _context.Category.Find(c => c.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Category> GetByName(string name)
        {
            return await _context.Category.Find(c => c.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<bool> HasExists(string name)
        {
            return await _context.Category.Find(c => c.Name.Equals(name)).AnyAsync();
        }
    }
}
