using Loja.Ecommerce.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Loja.Ecommerce.Infra.Context
{
    public class ContextMongo
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase db;

        public ContextMongo(IConfiguration configuration)
        {
            var conn = configuration.GetSection("MongoDb:ConnectionString").Value;
            client = new MongoClient(conn);
            db = client.GetDatabase("LojaDB");
        }

        public IMongoCollection<Product> Product
        {
            get
            {
                return db.GetCollection<Product>("Products");
            }
        }

        public IMongoCollection<Category> Category
        {
            get
            {
                return db.GetCollection<Category>("Categories");
            }
        }
    }
}
