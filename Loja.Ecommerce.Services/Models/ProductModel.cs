namespace Loja.Ecommerce.Services.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        
    }
}
