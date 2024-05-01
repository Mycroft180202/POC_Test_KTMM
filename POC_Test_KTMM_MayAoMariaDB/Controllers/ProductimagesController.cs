using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POC_Test_KTMM_MayAoMariaDB.Models;

namespace POC_Test_KTMM_MayAoMariaDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductimagesController : ControllerBase
    {
        private readonly CuahangtrasuaContext _context;

        public ProductimagesController(CuahangtrasuaContext context)
        {
            _context = context;
        }

        // GET: api/Productimages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productimage>>> GetProductimages()
        {
            return await _context.Productimages.ToListAsync();
        }

        // GET: api/Productimages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productimage>> GetProductimage(int id)
        {
            var productimage = await _context.Productimages.FindAsync(id);

            if (productimage == null)
            {
                return NotFound();
            }

            return productimage;
        }

        // PUT: api/Productimages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductimage(int id, Productimage productimage)
        {
            if (id != productimage.ImageId)
            {
                return BadRequest();
            }

            _context.Entry(productimage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductimageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Productimages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Productimage>> PostProductimage(Productimage productimage)
        {
            _context.Productimages.Add(productimage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductimageExists(productimage.ImageId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductimage", new { id = productimage.ImageId }, productimage);
        }

        // DELETE: api/Productimages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductimage(int id)
        {
            var productimage = await _context.Productimages.FindAsync(id);
            if (productimage == null)
            {
                return NotFound();
            }

            _context.Productimages.Remove(productimage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductimageExists(int id)
        {
            return _context.Productimages.Any(e => e.ImageId == id);
        }
    }
}
