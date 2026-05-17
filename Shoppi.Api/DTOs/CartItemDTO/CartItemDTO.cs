namespace Shoppi.Api.DTOs.CartItemDTO
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public string ProductDescription { get; set; } = "";
        public string ProductImageUrl { get; set; } = "";
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
