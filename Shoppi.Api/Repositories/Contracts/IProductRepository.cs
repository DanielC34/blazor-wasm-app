using Shoppi.Api.Entities;
using Shoppi.Client.DTOs.ProductDTOClient;

namespace Shoppi.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(); // Get all products
        Task<Product?> GetProductByIdAsync(int id); // Get a product by its ID

        Task AddProductAsync(Product product); // Add a new product
        Task UpdateProductAsync(Product product); // Update an existing product
        Task<bool> DeleteProductAsync(int id); // Delete a product by its ID
       

        Task<IEnumerable<ProductCategory>> GetCategoriesAsync(); // Get product categories
    }
}
