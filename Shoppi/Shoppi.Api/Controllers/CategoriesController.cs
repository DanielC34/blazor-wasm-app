using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoppi.Api.Data;
using Shoppi.Api.DTOs.CategoryDTO;
using Shoppi.Api.Entities;

namespace Shoppi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories() 
        {
            var categories = await _context.ProductCategories
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return Ok(categories);
        }
    }
}