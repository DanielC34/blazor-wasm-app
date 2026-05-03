using Shoppi.Client.DTOs.ProductDTOClient;

namespace Shoppi.Client.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTOClient>> GetProducts();
        Task<ProductDTOClient?> GetProductById(int id);
        Task<ProductDTOClient?> AddProduct(ProductDTOClient product);
        Task<bool> UpdateProduct(ProductDTOClient product);
        Task<bool> DeleteProduct(int id); 
        Task<List<CategoryDTOClient>> GetCategories(); // Get all categories
    }
}