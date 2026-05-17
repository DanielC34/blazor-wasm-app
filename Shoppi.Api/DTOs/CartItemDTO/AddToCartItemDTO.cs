namespace Shoppi.Api.DTOs.CartItemDTO
{
    public class AddToCartItemDTO
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
