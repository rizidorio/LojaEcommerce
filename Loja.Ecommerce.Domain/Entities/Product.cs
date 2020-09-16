using MongoDB.Bson;

namespace Loja.Ecommerce.Domain.Entities
{
    public class Product
    {
        public ObjectId Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        
    }
}
