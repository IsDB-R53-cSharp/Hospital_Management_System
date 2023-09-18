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


        //Get: Api/Patient

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientRegister>>> GetAllPatient()
        {
            //return await _context.PatientRegisters.ToListAsync();
            return await _context.PatientRegisters.FromSqlRaw("SpAllPatient").ToListAsync();
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
            //_context.PatientRegisters.Add(patient);
            //await _context.SaveChangesAsync();
            //return Ok(patient);

            _context.Database.ExecuteSqlRaw("EXEC SPpatientInsert @patinetName={0}, @gender={1},@dateOfBirth={2}, @address={3}, @phoneNumber={4},  @email={5},@emergencyContact={6},@admissionDate={7}, @bloodType={8}, @isTransferred={9},@wardId={10}", patient.PatientName, patient.Gender, patient.DateOfBirth, patient.Address, patient.PhoneNumber,patient.Email,patient.EmergencyContact,patient.AdmissionDate, patient.BloodType, patient.IsTransferred, patient.WardID);
            await _context.SaveChangesAsync();  
            return Ok(patient);
        }

        // PUT: api/Patient
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientRegister patient)
        {
            //if (id != patient.PatientID)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(patient).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PatientExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            ////return NoContent();

            //return Ok(patient);

            _context.Database.ExecuteSqlRaw("EXEC SPpatientUpdate @patientId={0}, @patinetName={1}, @gender={2},@dateOfBirth={3}, @address={4}, @phoneNumber={5},  @email={6},@emergencyContact={7},@admissionDate={8}, @bloodType={9}, @isTransferred={10},@wardId={11}", id, patient.PatientName, patient.Gender, patient.DateOfBirth, patient.Address, patient.PhoneNumber, patient.Email,patient.EmergencyContact, patient.AdmissionDate, patient.BloodType, patient.IsTransferred, patient.WardID);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }


        // DELETE: api/Patient 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            //var patient = await _context.PatientRegisters.FindAsync(id);
            //if (patient == null)
            //{
            //    return NotFound();
            //}

            //_context.PatientRegisters.Remove(patient);
            //await _context.SaveChangesAsync();

            //return Ok("data deleted successfully!!");

            var patient = await _context.PatientRegisters.FindAsync(id);
            _context.Database.ExecuteSqlRaw("EXEC SpPatientDelete @patientId={0}", id);
            if (patient == null)
            {
                return BadRequest("Patient id is invalid");
            }
            return Ok("data deleted successfully");
        }

        //private bool PatientExists(int id)
        //{
        //    return _context.PatientRegisters.Any(e => e.PatientID == id);
        //}




        //        [HttpGet]
        //        [Route("")]
        //        public IActionResult Index()
        //        {
        //            var patients = _context.PatientRegisters.ToList();
        //            return View(patients);
        //        }

        //        [HttpGet]
        //        [Route("details/{id}")]
        //        public IActionResult Details(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var patient = _context.PatientRegisters
        //                .FirstOrDefault(m => m.PatientID == id);

        //            if (patient == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(patient);
        //        }

        //        [HttpGet]
        //        [Route("create")]
        //        public IActionResult Create()
        //        {
        //            return View();
        //        }

        //        [HttpPost]
        //        [Route("create")]
        //        [ValidateAntiForgeryToken]
        //        public IActionResult Create([Bind("PatientID,PatientName,Gender,AdmissionDate,DateOfBirth,Address,EmergencyContact,Phone,Email,BloodType,IsTransferred,WardID")] PatientRegister patientRegister)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                _context.Add(patientRegister);
        //                _context.SaveChanges();
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(patientRegister);
        //        }

        //        [HttpGet]
        //        [Route("edit/{id}")]
        //        public IActionResult Edit(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var patient = _context.PatientRegisters.Find(id);

        //            if (patient == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(patient);
        //        }

        //        [HttpPost]
        //        [Route("edit/{id}")]
        //        [ValidateAntiForgeryToken]
        //        public IActionResult Edit(int id, [Bind("PatientID,PatientName,Gender,AdmissionDate,DateOfBirth,Address,EmergencyContact,Phone,Email,BloodType,IsTransferred,WardID")] PatientRegister patientRegister)
        //        {
        //            if (id != patientRegister.PatientID)
        //            {
        //                return NotFound();
        //            }

        //            if (ModelState.IsValid)
        //            {
        //                try
        //                {
        //                    _context.Update(patientRegister);
        //                    _context.SaveChanges();
        //                }
        //                catch (DbUpdateConcurrencyException)
        //                {
        //                    if (!PatientExists(patientRegister.PatientID))
        //                    {
        //                        return NotFound();
        //                    }
        //                    else
        //                    {
        //                        throw;
        //                    }
        //                }
        //                return RedirectToAction(nameof(Index));
        //            }
        //            return View(patientRegister);
        //        }

        //        [HttpGet]
        //        [Route("delete/{id}")]
        //        public IActionResult Delete(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var patient = _context.PatientRegisters
        //                .FirstOrDefault(m => m.PatientID == id);

        //            if (patient == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(patient);
        //        }

        //        [HttpPost]
        //        [Route("delete/{id}")]
        //        [ValidateAntiForgeryToken]
        //        public IActionResult DeleteConfirmed(int id)
        //        {
        //            var patient = _context.PatientRegisters.Find(id);
        //            _context.PatientRegisters.Remove(patient);
        //            _context.SaveChanges();
        //            return RedirectToAction(nameof(Index));
        //        }

        //        private bool PatientExists(int id)
        //        {
        //            return _context.PatientRegisters.Any(e => e.PatientID == id);
        //        }
        //    }
        //}









    }
}