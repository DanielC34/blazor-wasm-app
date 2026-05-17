using Microsoft.EntityFrameworkCore;
using Shoppi.Api.Data;
using Shoppi.Api.Entities;
using Shoppi.Api.Repositories.Contracts;

namespace Shoppi.Api.Repositories
{
    public class ProductRepository : IProductRepository // Implementation of the IProductRepository interface for managing products in the database.
    {
        private readonly AppDbContext _context;  // The application's EF Core DbContext. Provided by dependency injection.
        public ProductRepository(AppDbContext context) // Constructor that takes an AppDbContext as a parameter and assigns it to the private field _context.
        {
                _context = context; // Assigns the provided AppDbContext to the private field _context for use in the repository methods.
        }

        public async Task AddProductAsync(Product product) // Adds a new product to the database.
        {
            await _context.Products.AddAsync(product);  // Adds the product to the DbSet for tracking.
            await _context.SaveChangesAsync();  // Saves changes to the database, inserting the new product.
        }

        public async Task<bool> DeleteProductAsync(int id) // Deletes a product by its ID from the database. Returns true if deletion was successful, false if product was not found.
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() // Retrieves all products from the database.
        {
            return await _context.Products
                            .Include(p => p.Category)
                            .ToListAsync(); // Retrieves all products from the database, including their associated categories, and returns them as an IEnumerable<Product>.
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync() // Retrieves all product categories from the database.
        {
            return await _context.ProductCategories.AsNoTracking().ToListAsync(); // Retrieves all product categories from the database and returns them as an IEnumerable<ProductCategory>.
        }

        public async Task<Product?> GetProductByIdAsync(int id) // Retrieves a product by its ID from the database. If found, returns the product; otherwise, returns null.
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProductAsync(Product product) // Updates an existing product in the database.
        {
            // Step 1: Find the existing product in the database by its ID
            var existingProduct = await _context.Products.FindAsync(product.Id);

            // Step 2: Check if product was found
            if (existingProduct != null) 
            {
                // Step 3: Copy all new values from the incoming product to the tracked entity
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.ImageURL = product.ImageURL;
                existingProduct.QuantityInStock = product.QuantityInStock;
                existingProduct.CategoryId = product.CategoryId;

                // Step 4: Save the changes to the database
                await _context.SaveChangesAsync();
            }
        }
    }
}
