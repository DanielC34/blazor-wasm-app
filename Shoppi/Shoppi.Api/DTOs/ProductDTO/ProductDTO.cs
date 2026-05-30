namespace Shoppi.Api.DTOs.ProductDTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public string ImageURL { get; set; } = "";
        public int QuantityInStock { get; set; }
        // Foreign key
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
    }
}
