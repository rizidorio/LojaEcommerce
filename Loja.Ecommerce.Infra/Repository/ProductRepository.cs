using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Infra.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Ecommerce.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextMongo _context;

        public ProductRepository(ContextMongo context)
        {
            _context = context;
        }

        public async Task<Product> Insert(Product product)
        {
            try
            {
                await _context.Product.InsertOneAsync(product);
                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<Product> Update(Product product)
        {
            try
            {
                await _context.Product.ReplaceOneAsync(p => p.Id.Equals(product.Id), product);
                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task Delete(string id)
        {
            try
            {
                await _context.Product.DeleteOneAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            
        }

        public async Task<IEnumerable<Product>> GetAll(int skip = 0, int limit = 20)
        {
            try
            {
                return await _context.Product.Find(p => true).Skip(skip).Limit(limit).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }

        public async Task<Product> GetById(string id)
        {
            try
            {
                return await _context.Product.Find(p => p.Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<IEnumerable<Product>> GetByCategory(string category, int skip = 0, int limit = 20)
        {
            try
            {
                return await _context.Product.Find(p => p.Category.Name.Equals(category)).Skip(skip).Limit(limit).ToListAsync();
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<Product> GetBySku(string sku)
        {
            return await _context.Product.Find(p => p.SKU.Equals(sku)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetByName(string name, int skip = 0, int limit = 0)
        {
            try
            {
                return await _context.Product.Find(p => p.Name.ToUpper().Contains(name.ToUpper())).Skip(skip).Limit(limit).ToListAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<bool> HasExists(string sku)
        {
            try
            {
                return await _context.Product.Find(p => p.SKU.Equals(sku)).AnyAsync();
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }
    }
}
