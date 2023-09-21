using HMS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Helpers
{
    public class AmbulanceHelper
    {
        public AmbulanceHelper() { }
        public AmbulanceHelper(Ambulance ambulance) 
        { 
            this.AmbulanceID = ambulance.AmbulanceID;
            this.AmbulanceNumber = ambulance.AmbulanceNumber;
            this.LastLocation = ambulance.LastLocation;
            this.Availability = ambulance.Availability;
            this.EmployeeID = ambulance.EmployeeID;
        }

        public int AmbulanceID { get; set; }

        public string AmbulanceNumber { get; set; } = default!;

        public string LastLocation { get; set; } = default!;
        public bool Availability { get; set; }
 
        public int EmployeeID { get; set; }

        public Ambulance GetAmbulance()
        {
            Ambulance ambulance = new Ambulance();
            ambulance.AmbulanceID=this.AmbulanceID;
            ambulance.AmbulanceNumber=this.AmbulanceNumber;
            ambulance.LastLocation=this.LastLocation;
            ambulance.Availability=this.Availability;
            ambulance.EmployeeID=this.EmployeeID;
            return ambulance;
        }
    }
}
