using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Infra.Context;
using MongoDB.Driver;
using System;
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
            try
            {
                await _context.Category.InsertOneAsync(category);
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public async Task<Category> Update(Category category)
        {
            try
            {
                await _context.Category.ReplaceOneAsync(c => c.Id.Equals(category.Id), category);
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }

        public async Task<bool> Delete(Category category)
        {
            try
            {
                DeleteResult deleteResult = await _context.Category.DeleteOneAsync(c => c.Id.Equals(category.Id));
                return deleteResult.IsAcknowledged;
            }
            catch (Exception ex)
            {
               throw ex;
            }          
        }

        public async Task<IEnumerable<Category>> GetAll(int skip, int limit)
        {

            try
            {
                return await _context.Category.Find(c => true).Skip(skip).Limit(limit).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        public async Task<Category> GetById(string id)
        {
            try
            {
                return await _context.Category.Find(c => c.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public async Task<Category> GetByName(string name)
        {
            try
            {
                return await _context.Category.Find(c => c.Name.Equals(name)).FirstOrDefaultAsync();
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }

        public async Task<bool> HasExists(string name)
        {
            try
            {
                return await _context.Category.Find(c => c.Name.Equals(name)).AnyAsync();
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }
    }
}
