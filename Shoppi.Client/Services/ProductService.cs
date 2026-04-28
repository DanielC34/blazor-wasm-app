using Shoppi.Client.DTOs.ProductDTOClient;
using Shoppi.Client.Services.Contracts;
using System.Net.Http.Json;

namespace Shoppi.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        // Get all products with error handling
        public async Task<IEnumerable<ProductDTOClient>> GetProducts()
        {
            try
            {
                return await _http.GetFromJsonAsync<IEnumerable<ProductDTOClient>>("api/products")
                       ?? new List<ProductDTOClient>();
            }
            catch
            {
                return new List<ProductDTOClient>();
            }
        }

        // Get a single product by ID with error handling
        public async Task<ProductDTOClient?> GetProductById(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<ProductDTOClient>($"api/products/{id}");
            }
            catch
            {
                return null;
            }
        }

        // Delete a product by ID with error handling
        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/products/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // Update a product with error handling
        public async Task<bool> UpdateProduct(ProductDTOClient product)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/products/{product.Id}", product);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // Add a new method to add a product
        public async Task<ProductDTOClient?> AddProduct(ProductDTOClient product)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/products", product);

                if (!response.IsSuccessStatusCode)
                    return null;

                return await response.Content.ReadFromJsonAsync<ProductDTOClient>();
            }
            catch
            {
                return null;
            }
        }
    }
}