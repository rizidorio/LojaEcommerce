using MongoDB.Bson;

namespace Loja.Ecommerce.Domain.Entities
{
    public class Category
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
