namespace Shoppi.Api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }

        public string Description { get; set; } = "";
        public string ImageURL { get; set; } = "";
        public int QuantityInStock { get; set; }
        // Foreign key
        public ProductCategory? Category { get; set; }

        public int CategoryId { get; set; }
        
    }
}
