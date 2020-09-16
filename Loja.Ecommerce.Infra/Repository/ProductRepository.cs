using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Infra.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Loja.Ecommerce.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextMongo _context;

        public ProductRepository(ContextMongo context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll(int skip = 0, int limit = 20)
        {
            return _context.Product.Find(p => true).Skip(skip).Limit(limit).ToList();
        }

        public Product GetById(ObjectId id)
        {
            return _context.Product.Find(p => p.Id.Equals(id)).FirstOrDefault();
        }

        public bool HasExists(string sku)
        {
            return _context.Product.Find(p => p.SKU.Equals(sku)).Any();
        }

        public void Save(Product product)
        {
            _context.Product.InsertOne(product);
        }

        public void Update(Product product)
        {
            _context.Product.ReplaceOne(p => p.Id.Equals(product.Id), product);
        }

        public void Delete(ObjectId id)
        {
            _context.Product.DeleteOne(p => p.Id.Equals(id));
        }
    }
}
