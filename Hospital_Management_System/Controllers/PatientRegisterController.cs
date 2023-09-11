using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRegisterController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        public PatientRegisterController(HospitalDbContext _context)
        {
            this._context = _context;   
        }

        //Get: Api/Patient

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientRegister>>> GetAllPatient()
        {
            return await _context.PatientRegisters.ToListAsync();
        }

        // GET: api/Patient By ID

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientRegister>> GetPatient(int id)
        {
            var patient = await _context.PatientRegisters.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<ActionResult<PatientRegister>> CreatePatient(PatientRegister patient)
        {
            _context.PatientRegisters.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientID }, patient);
        }

        // PUT: api/Patient
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientRegister patient)
        {
            if (id != patient.PatientID)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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


        // DELETE: api/Patient 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.PatientRegisters.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.PatientRegisters.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.PatientRegisters.Any(e => e.PatientID == id);
        }

    }
}
