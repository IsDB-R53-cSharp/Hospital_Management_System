using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediciensController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public MediciensController(HospitalDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetAllMedicine()
        {
            var medicines = await _context.Medicines.FromSqlRaw("EXEC SpAllMedicine").ToListAsync();
            return Ok(medicines);
        }
        [HttpGet("{id}")]
        public ActionResult GetMedicineById(int id)
        {
            var idParameter = new SqlParameter("@id", id);

            IQueryable<Medicine> medicine = _context.Medicines
                .FromSqlRaw("EXEC SpMedicineById @id", idParameter)
                .AsQueryable();

            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }


        [HttpPost]
        [Route("PostMedicine")]
        public async Task<ActionResult<Medicine>> PostMedicine([FromForm] Medicine medicine)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw("EXEC SpPostMedicine @MedicineName={0}, @Strength={1}, @MedicineType={2}, @ExpireDate={3},@Quantity={4},@SellPrice={5},@Discount={6},@MedicineGenericID={7},@ManufacturerID ={8}"
                    ,
                         medicine.MedicineName, medicine.Strength, medicine.MedicineType, medicine.ExpireDate, medicine.Quantity, medicine.SellPrice, medicine.Discount, medicine.MedicineGenericID, medicine.ManufacturerID);

                    transaction.Commit();
                    return Ok("Medicine inserted successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest($"Failed to insert Medicine. Error: {ex.Message}");
                }
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Medicine>> UpdateMedicine(int id, [FromForm] Medicine medicine)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw("EXEC SpUpdateMedicine @id={0}, @MedicineName={1}, @Strength={2}, @MedicineType={3}, @ExpireDate={4},@Quantity={5},@SellPrice={6},@Discount={7},@MedicineGenericID={8},@ManufacturerID ={9}"
                    ,
                        id, medicine.MedicineName, medicine.Strength, medicine.MedicineType, medicine.ExpireDate, medicine.Quantity, medicine.SellPrice, medicine.Discount, medicine.MedicineGenericID, medicine.ManufacturerID);

                    transaction.Commit();
                    return Ok("Medicine Update successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest($"Failed to Update Medicine. Error: {ex.Message}");
                }
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            var medicine = await _context.PatientRegisters.FindAsync(id);
            _context.Database.ExecuteSqlRaw("EXEC SpDeleteMedicine @id={0}", id);
            if (medicine == null)
            {
                return BadRequest("Medicine id is invalid");
            }
            return Ok("data deleted successfully");
        }


    }
}
