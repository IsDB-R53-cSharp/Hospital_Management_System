using HMS.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using HMS.Models;
using Hospital_Management_System.Helpers;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly ImageHelper _imageHelper;

        public DoctorsController(IDoctorRepo doctorRepo, ImageHelper imageHelper)
        {
            _doctorRepo = doctorRepo;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        [Route("GetDoctor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDoctor()
        {
            try
            {
                var doctors = _doctorRepo.GetDoctors().ToList();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDoctorById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDoctorById(int id)
        {
            try
            {
                Doctor doctor = _doctorRepo.GetDoctorById(id);

                if (doctor == null)
                {
                    return NotFound($"Doctor with ID {id} not found.");
                }

                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> PostDoctor([FromForm] DoctorHelper doctorHelper)
        {
            try
            {
                // Handle image upload
                string imagePath = await _imageHelper.SaveImageAsync(doctorHelper.Image);

                if (imagePath == null)
                {
                    return BadRequest("Image upload failed.");
                }

                Doctor doctorToSave = doctorHelper.GetDoctor();
                doctorToSave.Image = imagePath;

                _doctorRepo.SaveDoctor(doctorToSave);

                return Ok(doctorToSave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutDoctor(int id, [FromForm] DoctorHelper doctorHelper)
        {
            try
            {
                // Handle image upload
                string imagePath = await _imageHelper.SaveImageAsync(doctorHelper.Image);

                Doctor existingDoctor = _doctorRepo.GetDoctorById(id);

                if (existingDoctor == null)
                {
                    return NotFound($"Doctor with ID {id} not found.");
                }

                // Update the existing doctor's properties
                existingDoctor.DepartmentID = doctorHelper.DepartmentID;
                existingDoctor.DoctorName = doctorHelper.DoctorName;
                existingDoctor.Specialization = doctorHelper.Specialization;
                existingDoctor.Doctortype = doctorHelper.doctortype;
                existingDoctor.JoinDate = doctorHelper.JoinDate;
                existingDoctor.Image = imagePath; 
                existingDoctor.Education_Info = doctorHelper.Education_Info;
                //existingDoctor.Department = doctorHelper.Department;
                //existingDoctor.Prescriptions = doctorHelper.Prescriptions;
                //existingDoctor.Appointments = doctorHelper.Appointments;
                //existingDoctor.SurgeryProcedures = doctorHelper.SurgeryProcedures;

                _doctorRepo.SaveDoctor(existingDoctor);

                return Ok(existingDoctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            try
            {
                Doctor existingDoctor = _doctorRepo.GetDoctorById(id);
                if (existingDoctor == null)
                {
                    return NotFound($"Doctor with ID {id} not found.");
                }

                return BadRequest("Doctor can't be deleted. Change doctor status instead.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}