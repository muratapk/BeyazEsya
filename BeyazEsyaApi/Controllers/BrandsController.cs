using BeyazEsyaApi.Data;
using BeyazEsyaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeyazEsyaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BeyazEsyaDb _context;

        public BrandsController(BeyazEsyaDb context)
        {
            _context = context;
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Brands>>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<ActionResult<Brands>>GetBrands(int id)
        {
            return await _context.Brands.FindAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult>BrandAdd(Brands brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("id")]
        public async Task<ActionResult<Brands>>Delete(int id)
        {
            var result = await _context.Brands.Where(x => x.BrandId == id).FirstOrDefaultAsync();
            if(result==null)
            {
                return NotFound();
            }
            _context.Brands.Remove(result);
            await _context.SaveChangesAsync();
            return result;

        }
        [HttpPut("id")]
        public async Task<ActionResult<Brands>> UpdateBrands(int id, Brands brand)
        {
            var result = await _context.Brands.Where(x => x.BrandId == id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Name = brand.Name;
                result.Description = brand.Description;
                _context.Brands.Update(result);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return result;
        }
    }
}
