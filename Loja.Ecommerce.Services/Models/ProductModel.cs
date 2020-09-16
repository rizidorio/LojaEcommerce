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

        [Required(ErrorMessage = "SKU é obrigatório.")]
        public string SKU { get; set; }
        
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Marca é obrigatório.")]
        public string Brand { get; set; }
        
        public string ImageUrl { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Category { get; set; }
        
        [Required(ErrorMessage = "Preço é obrigatório.")]
        public decimal Price { get; set; }
        
    }
}
