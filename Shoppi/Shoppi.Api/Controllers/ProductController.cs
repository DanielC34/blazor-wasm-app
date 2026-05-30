using Microsoft.AspNetCore.Mvc;
using Shoppi.Api.DTOs.ProductDTO;
using Shoppi.Api.Mappings;
using Shoppi.Api.Repositories.Contracts;

namespace Shoppi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await _repository.GetAllProductsAsync(); 
            return Ok(ProductMapper.ToDtoList(products)); // Map entities to DTOs before returning
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);

            if (product == null)
                return NotFound(new { message = $"Product with ID {id} not found." });

            return Ok(ProductMapper.ToDto(product));
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
                return BadRequest(new { message = "Product cannot be null." });

            if (string.IsNullOrWhiteSpace(productDto.Name))
                return BadRequest(new { message = "Product name is required." });

            if (productDto.Price <= 0)
                return BadRequest(new { message = "Price must be greater than zero." });

            if (productDto.CategoryId <= 0)
                return BadRequest(new { message = "Valid category ID is required." });

            var product = ProductMapper.ToEntity(productDto);
            await _repository.AddProductAsync(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, ProductMapper.ToDto(product));
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDto)
        {
            if (productDto == null)
                return BadRequest(new { message = "Product cannot be null." });

            if (id != productDto.Id)
                return BadRequest(new { message = "Product ID in URL does not match body." });

            if (string.IsNullOrWhiteSpace(productDto.Name))
                return BadRequest(new { message = "Product name is required." });

            if (productDto.Price <= 0)
                return BadRequest(new { message = "Price must be greater than zero." });

            var existingProduct = await _repository.GetProductByIdAsync(id);
            if (existingProduct == null)
                return NotFound(new { message = $"Product with ID {id} not found." });

            var product = ProductMapper.ToEntity(productDto);
            await _repository.UpdateProductAsync(product);

            return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "Product ID must be greater than zero." });

            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
                return NotFound(new { message = $"Product with ID {id} not found." });

            var success = await _repository.DeleteProductAsync(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
