using HMS.DAL.Data;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvicesController : ControllerBase
    {
        private readonly HospitalDbContext db;
        public AdvicesController(HospitalDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetallAdvice()
        {
            IQueryable<Advice> advices = db.Advices.FromSqlRaw("GetAdviceList").AsQueryable();
            if (advices == null)
            {
                return NotFound();
            }

            return Ok(advices);
        }
        [HttpPost]
        public IActionResult InsertAdvice([FromForm] Advice advice)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlRaw("EXEC InsertAdvice @AdviceName={0}",
                        advice.AdviceName);

                    transaction.Commit();
                    return Ok("Advice inserted successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest($"Failed to insert Advice. Error: {ex.Message}");
                }
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateAdvice(int id, [FromForm] Advice advice)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Database.ExecuteSqlRaw("EXEC UpdateAdvice @id={0}, @AdviceName={1}",
                        id, advice.AdviceName);

                    transaction.Commit();
                    return Ok("Advice updated successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest($"Failed to update Advice. Error: {ex.Message}");
                }
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAdvice(int id)
        {
            var ID = db.Advices.Find(id);

            db.Database.ExecuteSqlRaw("EXEC DeleteAdvice @id={0}", id);
            if (ID == null)
            {
                return BadRequest("No Id Found!!!");
            }
            return Ok("Advice deleted successfully.");
        }
    }
}
