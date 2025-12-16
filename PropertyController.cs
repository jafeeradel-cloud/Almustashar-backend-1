
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Data;
using RealEstateApi.Models;

namespace RealEstateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropertyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddProperty([FromBody] Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Property>>> SearchProperties(
            [FromQuery] string propertyType, [FromQuery] string location, [FromQuery] decimal? price)
        {
            var query = _context.Properties.AsQueryable();

            if (!string.IsNullOrEmpty(propertyType))
                query = query.Where(p => p.PropertyType.Contains(propertyType));
            if (!string.IsNullOrEmpty(location))
                query = query.Where(p => p.Location.Contains(location));
            if (price.HasValue)
                query = query.Where(p => p.Price <= price);

            return await query.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] Property property)
        {
            if (id != property.Id)
            {
                return BadRequest();
            }

            _context.Entry(property).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return property;
        }
    }
}
