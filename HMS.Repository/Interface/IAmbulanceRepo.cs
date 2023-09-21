using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IAmbulanceRepo
    {
        IEnumerable<Ambulance> GetAmbulances();
        Ambulance GetAmbulanceById(int id);
        void SaveAmbulance(Ambulance ambulance);
        void DeleteAmbulance(int id);
    }
}
