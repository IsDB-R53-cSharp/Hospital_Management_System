using HMS.DAL.Generic_Interface;
using HMS.Models;
using HMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//using static HMS.Models.DbModels;

namespace HMS.Repository.Implementation
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly IGenericRepo<Doctor> _doctorRepo;

        public DoctorRepo(IGenericRepo<Doctor> doctorRepo)
        {
            this._doctorRepo = doctorRepo;
        }
        public IEnumerable<Doctor> GetDoctors()
        {
            try
            {
                return _doctorRepo.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Doctor GetDoctorById(int id)
        {
            try
            {
                return _doctorRepo.FindByCondition(x => x.DoctorID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveDoctor(Doctor doctor)
        {
            try
            {
                if (doctor.DoctorID > 0)
                {
                    if (doctor.Image == null)
                    {
                        Doctor existingDoctor = _doctorRepo.FindByCondition(x => x.DoctorID == doctor.DoctorID).FirstOrDefault();
                        doctor.Image = existingDoctor.Image;
                    }
                    _doctorRepo.Update(doctor);
                }
                else
                {
                    _doctorRepo.Create(doctor);
                }
                _doctorRepo.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteDoctor(int id)
        {
            _doctorRepo.Delete(id);
            _doctorRepo.Commit();
        }
    }
}
