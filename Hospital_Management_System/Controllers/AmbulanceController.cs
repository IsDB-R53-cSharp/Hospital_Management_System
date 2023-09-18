﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Models; 
using HMS.DAL.Data;
using Microsoft.AspNet.Identity;


namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbulancesController : ControllerBase
    {
        private readonly HospitalDbContext db;

        public AmbulancesController(HospitalDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ambulance>>> GetAmbulances()
        {
            return await db.Ambulances.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ambulance>> GetAmbulance(int id)
        {
            var ambulance = await db.Ambulances.FindAsync(id);

            if (ambulance == null)
            {
                return NotFound();
            }

            return ambulance;
        }

        [HttpPost]
        public async Task<ActionResult<Ambulance>> CreateAmbulance(Ambulance ambulance)
        {
            await db.Database.ExecuteSqlRawAsync("EXEC InsertAmbulance @AmbulanceNumber={0}, @PhoneNumber={1}, @DrivingLiense={2}, @DriverName={3}, @LastLocation={4},@Availability={5}", ambulance.AmbulanceNumber, ambulance.PhoneNumber, ambulance.DrivingLiense, ambulance.DriverName, ambulance.LastLocation, ambulance.Availability);
            return Ok("Ambulance inserted successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAmbulance(int id, Ambulance ambulance)
        {

          await  db.Database.ExecuteSqlRawAsync("EXEC UpdateAmbulance  @AmbulanceID={0}, @AmbulanceNumber={1}, @PhoneNumber={2}, @DrivingLiense={3}, @DriverName={4}, @LastLocation={5},@Availability={6}", ambulance.AmbulanceID,ambulance.AmbulanceNumber, ambulance.PhoneNumber, ambulance.DrivingLiense, ambulance.DriverName, ambulance.LastLocation, ambulance.Availability);
            return Ok("Ambulance Update successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmbulance(int id)
        {
            var ID =await db.Ambulances.FirstOrDefaultAsync(x => x.AmbulanceID == id);
            await db.Database.ExecuteSqlRawAsync("EXEC DeleteAmbulance @AmbulanceID={0}", ID);
            if (ID == null)
            {
                return BadRequest(" Ambulance Data Not Found!!!");
            }
            return Ok("Ambulance deleted successfully.");
        }


    }
}