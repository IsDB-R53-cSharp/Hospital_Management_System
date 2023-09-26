using HMS.DAL.Data;
using HMS.DAL.Migrations;
using HMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidentifiedDeadBodysController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly ILogger<UnidentifiedDeadBodysController> _logger;

        public UnidentifiedDeadBodysController(HospitalDbContext context, ILogger<UnidentifiedDeadBodysController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetUnidentifiedDeadBody()
        {
            try
            {
                var unidentifiedDeadBody = _context.unidentifiedDeadBodies.FromSqlRaw("EXEC SpAllUnidentifiedDeadBody").ToList();
                return Ok(unidentifiedDeadBody);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving unidentified DeadBody records.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult PostUnidentifiedDeadBody([FromBody] UnidentifiedDeadBody unidentifiedDeadBody)
        {
            _context.Database.ExecuteSqlRaw("EXEC InsertUnidentifiedDeadBody @TagNumber ={1}, @DeceasedName ={2}, @DateOfDeath ={3}, @CauseOfDeath ={4}", unidentifiedDeadBody.TagNumber, unidentifiedDeadBody.DeceasedName, unidentifiedDeadBody.DateOfDeath, unidentifiedDeadBody.CauseOfDeath);

            return Ok("unidentifiedDeadBody inserted successfully");
        }

        [HttpPut("{id}")]
        public IActionResult PutUnidentifiedDeadBody(int id, [FromBody] UnidentifiedDeadBody unidentifiedDeadBody)
        {
            _context.Database.ExecuteSqlRaw("EXEC UpdateUnidentifiedDeadBody @TagNumber ={1}, @DeceasedName ={2}, @DateOfDeath ={3}, @CauseOfDeath ={4}", unidentifiedDeadBody.TagNumber, unidentifiedDeadBody.DeceasedName, unidentifiedDeadBody.DateOfDeath, unidentifiedDeadBody.CauseOfDeath);


            return Ok("unidentifiedDeadBody Updated successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUpdateUnidentifiedDeadBody(int id)
        {
            var ID = _context.unidentifiedDeadBodies.FirstOrDefault(x => x.UnIdenfiedDeadBodyID == id);

            _context.Database.ExecuteSqlRaw("EXEC DeleteUnidentifiedDeadBody @UnIdenfiedDeadBodyID={0}", id);
            if (ID != null)
            {
                return Ok("UnidentifiedDeadBody Delete Successfully");
            }
            return BadRequest("UnidentifiedDeadBody Invalid Data");
        }
    }
}
