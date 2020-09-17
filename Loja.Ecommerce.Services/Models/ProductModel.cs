using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Loja.Ecommerce.Services.Models
{
    public class ProductModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string SKU { get; set; }

        [BsonRequired]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [BsonRequired]
        public string Brand { get; set; }
        
        public string ImageUrl { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Category { get; set; }
        
        [BsonRequired]
        public decimal Price { get; set; }
        
    }
}
