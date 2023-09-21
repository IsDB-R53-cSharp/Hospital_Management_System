using HMS.Models;
using HMS.Repository.Interface;
using Hospital_Management_System.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbulancesController : ControllerBase
    {
        private readonly IAmbulanceRepo repo;
        private readonly IWebHostEnvironment env;
        public AmbulancesController(IAmbulanceRepo repo, IWebHostEnvironment env)
        {
            this.repo = repo;
            this.env = env;
        }
        [HttpGet]
        [Route("GetAmbulances")]
        public IActionResult GetAmbulances()
        {
            try
            {
                var ambulace = repo.GetAmbulances().ToList();
                return Ok(ambulace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAmbulanceById/{id}")]
        public IActionResult GetAmbulanceById(int id)
        {
           
            try
            {
                Ambulance ambulance=repo.GetAmbulanceById(id);
                if (ambulance == null)
                {
                    return NotFound($"Ambulance with ID:  {id} not found.");
                }
                return Ok(ambulance);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message );
            }
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> PostAmbulance([FromForm] AmbulanceHelper ambulanceHelper)
        {
            try
            {
                Ambulance ambulanceToSave = ambulanceHelper.GetAmbulance();
                repo.SaveAmbulance(ambulanceToSave);
                return Ok(ambulanceToSave);
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutAmbulance(int id,[FromForm] AmbulanceHelper ambulanceHelper)
        {
            try
            {
                Ambulance existingAmbulance = repo.GetAmbulanceById(id);
                if (existingAmbulance==null)
                {
                    return NotFound($"Ambulance with ID: {id} not found.");
                }
                // Update the existing doctor's properties
                existingAmbulance.AmbulanceID=ambulanceHelper.AmbulanceID;
                existingAmbulance.AmbulanceNumber=ambulanceHelper.AmbulanceNumber;
                existingAmbulance.LastLocation=ambulanceHelper.LastLocation;
                existingAmbulance.Availability=ambulanceHelper.Availability;
                existingAmbulance.EmployeeID=ambulanceHelper.EmployeeID;

                repo.SaveAmbulance(existingAmbulance);
                return Ok(existingAmbulance);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAmbulace(int id)
        {
            try
            {
                Ambulance existingAmbulance = repo.GetAmbulanceById(id);
                if (existingAmbulance == null)
                {
                    return NotFound();
                }

                repo.DeleteAmbulance(id);

                // Return a success message
                return Ok($"Ambulance with ID: {id} has been deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
