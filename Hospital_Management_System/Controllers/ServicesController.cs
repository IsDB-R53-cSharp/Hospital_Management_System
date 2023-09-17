using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public ServicesController(HospitalDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            if (_context.Services == null)
            {
                return NotFound();
            }
            return await _context.Services.ToListAsync();
        }

        //id
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        //Post
        [HttpPost]
        public async Task<ActionResult<Service>> CreateService(Service service)
        {

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetService), new { id = service.ServiceID }, service);
        }


        //// PUT: api/Services/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutService(int id, Service service)
        //{
        //    if (id != service.ServiceID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(service).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ServiceExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
    }
}
