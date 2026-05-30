using Shoppi.Api.DTOs.ProductDTO;
using Shoppi.Api.Entities;

namespace Shoppi.Api.Mappings
{
    public static class ProductMapper // A static class that provides methods for mapping between Product entities and ProductDTOs.
    {
        public static ProductDTO ToDto(Product product) => new() // A method that takes a Product entity and returns a ProductDTO with the corresponding properties.
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            ImageURL = product.ImageURL,
            QuantityInStock = product.QuantityInStock,
            CategoryId = product.CategoryId,
            CategoryName = product.Category?.Name ?? ""
        };

        public static Product ToEntity(ProductDTO dto) => new() // A method that takes a ProductDTO and returns a Product entity with the corresponding properties. Note that the Category navigation property is not set here, only the CategoryId is assigned.
        {
            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            ImageURL = dto.ImageURL,
            QuantityInStock = dto.QuantityInStock,
            CategoryId = dto.CategoryId,
        };

        public static IEnumerable<ProductDTO> ToDtoList(IEnumerable<Product> products) =>
            products.Select(ToDto);
    }
}
