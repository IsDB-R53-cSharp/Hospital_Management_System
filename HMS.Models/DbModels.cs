using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models.SurgeryWard;

namespace HMS.Models
{
    //public class LabEquipment
    //{
    //    [Key]
    //    public int EquipmentID { get; set; }
    //    public string EquipmentName { get; set; } = default!;
    //    public string EquipmentDetails { get; set; } = default!;
    //    public int StockQuantity { get; set; }
    //    //public decimal PurchasePrice { get; set; }
    //    public int DepartmentID { get; set; }
    //    public Department Departments { get; set; } = default!;

    //}

    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentType { get; set; }
        public string TicketNumber { get; set; }
        public bool AppointmentStatus { get; set; }

        [NotMapped]
        public virtual Doctor Doctor { get; set; }
    }
    
    //DisCharge class Cut to outside
    //Medical records class cut to outside  --- controller not done

}
