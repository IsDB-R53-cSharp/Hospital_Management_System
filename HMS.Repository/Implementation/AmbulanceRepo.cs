using HMS.DAL.Generic_Interface;
using HMS.Models;
using HMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Implementation
{
    public class AmbulanceRepo : IAmbulanceRepo
    {
        private readonly IGenericRepo<Ambulance> _ambRepo;
        
        public AmbulanceRepo(IGenericRepo<Ambulance> ambRepo)
        {
            this._ambRepo = ambRepo;
        }
        public IEnumerable<Ambulance> GetAmbulances()
        {
            try
            {
                return _ambRepo.FindAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Ambulance GetAmbulanceById(int id)
        {
            try
            {
                return _ambRepo.FindByCondition(x => x.AmbulanceID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SaveAmbulance(Ambulance ambulance)
        {
            try
            {
                if (ambulance.AmbulanceID>0)
                {
                    Ambulance existingambulance=_ambRepo.FindByCondition(x=>x.AmbulanceID==ambulance.AmbulanceID).FirstOrDefault();
                    _ambRepo.Update(ambulance);
                }
                else
                {
                    _ambRepo.Create(ambulance);
                }
                _ambRepo.Commit();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteAmbulance(int id)
        {
            _ambRepo.Delete(id);
            _ambRepo.Commit();
        }
    }
}
