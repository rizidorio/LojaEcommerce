using Loja.Ecommerce.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.IO;

namespace Loja.Ecommerce.Infra.Context
{
    public class ContextMongo
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase db;
        public IConfigurationRoot Configuration { get; }

        public ContextMongo()
        {
            //Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            client = new MongoClient("mongodb://localhost:27017");
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
