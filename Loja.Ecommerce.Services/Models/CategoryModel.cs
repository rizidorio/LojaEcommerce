using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Loja.Ecommerce.Services.Models
{
    public class CategoryModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRequired]
        public string Name { get; set; }
    }
}
