using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawersController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public DrawersController(HospitalDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drawer>>> GetDrawers()
        {
            var drawers = await _context.Drawers.Include(d => d.Morgue).ToListAsync();
            return Ok(drawers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Drawer>> GetDrawer(int id)
        {
            var drawer = await _context.Drawers.Include(d => d.Morgue).FirstOrDefaultAsync(d => d.DrawerID == id);

            if (drawer == null)
            {
                return NotFound();
            }

            return Ok(drawer);
        }
        [HttpPost]
        public async Task<ActionResult<Drawer>> CreateDrawer(Drawer drawer)
        {
            _context.Drawers.Add(drawer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrawer", new { id = drawer.DrawerID }, drawer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrawer(int id, Drawer drawer)
        {
            if (id != drawer.DrawerID)
            {
                return BadRequest();
            }

            _context.Entry(drawer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrawerExists(id))
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrawer(int id)
        {
            var drawer = await _context.Drawers.FindAsync(id);
            if (drawer == null)
            {
                return NotFound();
            }

            _context.Drawers.Remove(drawer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrawerExists(int id)
        {
            return _context.Drawers.Any(e => e.DrawerID == id);
        }
    }
}
