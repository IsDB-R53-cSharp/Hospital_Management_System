using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedsController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        public BedsController(HospitalDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bed>>> GetBeds()
        {
            var beds = await _context.Beds.ToListAsync();
            return Ok(beds);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Bed>>> GetBedsById(int id)
        {
            var beds= _context.Beds.FirstOrDefault(x=>x.BedID==id);
            return Ok(beds);
        }
        [HttpPost]
        public async Task<ActionResult<Bed>> PostBed(Bed bed)
        {
            _context.Beds.Add(bed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBed", new { id = bed.BedID }, bed);
        }

        // PUT: api/beds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBed(int id, Bed bed)
        {
            if (id != bed.BedID)
            {
                return BadRequest();
            }

            _context.Entry(bed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BedExists(id))
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

        private bool BedExists(int id)
        {
            return _context.Beds.Any(b => b.BedID == id);
        }
    }
}
