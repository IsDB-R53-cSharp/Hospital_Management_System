using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Models; // Make sure to import your model namespace
using HMS.DAL.Data;

namespace HMS.Controllers
{
    [Route("patients")]
    public class PatientRegisterController : Controller
    {
        private readonly HospitalDbContext _context;

        public PatientRegisterController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var patients = _context.PatientRegisters.ToList();
            return View(patients);
        }

        [HttpGet]
        [Route("details/{id}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = _context.PatientRegisters
                .FirstOrDefault(m => m.PatientID == id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PatientID,PatientName,Gender,AdmissionDate,DateOfBirth,Address,EmergencyContact,Phone,Email,BloodType,IsTransferred,WardID")] PatientRegister patientRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientRegister);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(patientRegister);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = _context.PatientRegisters.Find(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PatientID,PatientName,Gender,AdmissionDate,DateOfBirth,Address,EmergencyContact,Phone,Email,BloodType,IsTransferred,WardID")] PatientRegister patientRegister)
        {
            if (id != patientRegister.PatientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientRegister);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patientRegister.PatientID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patientRegister);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = _context.PatientRegisters
                .FirstOrDefault(m => m.PatientID == id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient = _context.PatientRegisters.Find(id);
            _context.PatientRegisters.Remove(patient);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return _context.PatientRegisters.Any(e => e.PatientID == id);
        }
    }
}









//old code
//using HMS.DAL.Data;
//using HMS.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;


//namespace Hospital_Management_System.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PatientRegisterController : ControllerBase
//    {
//        private readonly HospitalDbContext _context;
//        public PatientRegisterController(HospitalDbContext _context)
//        {
//            this._context = _context;   
//        }

//        //Get: Api/Patient

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<PatientRegister>>> GetAllPatient()
//        {
//            return await _context.PatientRegisters.ToListAsync();
//        }

//        // GET: api/Patient By ID

//        [HttpGet("{id}")]
//        public async Task<ActionResult<PatientRegister>> GetPatient(int id)
//        {
//            var patient = await _context.PatientRegisters.FindAsync(id);

//            if (patient == null)
//            {
//                return NotFound();
//            }

//            return patient;
//        }

//        // POST: api/Patient
//        [HttpPost]
//        public async Task<ActionResult<PatientRegister>> CreatePatient(PatientRegister patient)
//        {
//            _context.PatientRegisters.Add(patient);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientID }, patient);
//        }

//        // PUT: api/Patient
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdatePatient(int id, PatientRegister patient)
//        {
//            if (id != patient.PatientID)
//            {
//                return BadRequest();
//            }

//            _context.Entry(patient).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!PatientExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }


//        // DELETE: api/Patient 
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePatient(int id)
//        {
//            var patient = await _context.PatientRegisters.FindAsync(id);
//            if (patient == null)
//            {
//                return NotFound();
//            }

//            _context.PatientRegisters.Remove(patient);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool PatientExists(int id)
//        {
//            return _context.PatientRegisters.Any(e => e.PatientID == id);
//        }

//    }
//}
