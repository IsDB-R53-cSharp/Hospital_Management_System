using HMS.DAL.Data;
using HMS.Models;
using HMS.Models.SurgeryWard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers.Naeem
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly HospitalDbContext db;
        public PrescriptionsController(HospitalDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescriptions>>> GetPrescriptions()
        {
            var prs=await db.Prescriptions.ToListAsync();
            if (prs is null)
            {
                return BadRequest("Data Is Empty!!!!!");
            }
            else
            {
                return Ok(prs);
            }
        }
    }
}
