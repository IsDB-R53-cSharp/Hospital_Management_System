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
    public class BillController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public BillController(HospitalDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAllBills()
        {
            IQueryable<Bill> bills = _context.Bills.FromSqlRaw("GetAllBills").AsQueryable();
            if (bills == null)
            {
                return NotFound();
            }
            return Ok(bills);
        }

        [HttpGet("{id}")]
        public ActionResult GetBillById(int id)
        {
            var idParameter = new SqlParameter("@id", id);

            IQueryable<Bill> bills = _context.Bills
                .FromSqlRaw("EXEC GetBillById @id", idParameter)
                .AsQueryable();

            if (bills == null)
            {
                return NotFound();
            }

            return Ok(bills);
        }

        [HttpPost]
        public IActionResult InsertBill([FromForm] Bill bill)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Database.ExecuteSqlRaw("EXEC AddBills @PatientID={0}, @TransactionInfo={1}, @BillAmount={2}, @Discount={3}, @PaidAmount={4}, @Due={5},@PaymentMethod={6},@PaymentStatus={7}, @BillDate={8}, @isInsurance={9}, @InsuranceInfo={10}, @BillingAddress={11}, @BillingNotes={12}, @PreparedBy={13},@ServiceID={14} ",
                        bill.PatientID, bill.TransactionInfo, bill.BillAmount, bill.Discount, bill.PaidAmount, bill.Due, bill.PaymentMethod, bill.PaymentStatus, bill.BillDate, bill.isInsurance, bill.InsuranceInfo, bill.BillingAddress, bill.BillingNotes, bill.PreparedBy, bill.ServiceID);

                    transaction.Commit();
                    return Ok("Bill inserted successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest($"Failed to insert bill. Error: {ex.Message}");
                }
            }
        }
    }
}
