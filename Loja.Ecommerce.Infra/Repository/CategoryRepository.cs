using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Infra.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Loja.Ecommerce.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ContextMongo _context;

        public CategoryRepository(ContextMongo context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll(int skip = 0, int limit = 10)
        {
            return _context.Category.Find(c => true).Skip(skip).Limit(limit).ToList();
        }

        public Category GetById(ObjectId id)
        {
            return _context.Category.Find(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public bool HasExists(string name)
        {
            return _context.Category.Find(c => c.Name.Equals(name)).Any();
        }

        public void Save(Category category)
        {
            _context.Category.InsertOne(category);
        }

        public void Update(Category category)
        {
            _context.Category.ReplaceOne(c => c.Id.Equals(category.Id), category);
        }

        public void Delete(ObjectId id)
        {
            _context.Category.DeleteOne(c => c.Id.Equals(id));
        }
    }
}
