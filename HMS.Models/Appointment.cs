using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [ForeignKey("PatientRegister")]
        public int PatientID { get; set; }//for necessary info of patient

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        //[ForeignKey("Outdoor")]
        //public int OutdoorID { get; set; } //for TicketNumber and 

        public AppointmentType AppointmentType { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        [NotMapped]
        public List<Doctor>? Doctor { get; set; }
    }
    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }
    public enum AppointmentType
    {
        Indoor,
        Outdoor
    }
}
