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
    public class LabEquipment
    {
        [Key]
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; } = default!;
        public string EquipmentDetails { get; set; } = default!;
        public int StockQuantity { get; set; }
        //public decimal PurchasePrice { get; set; }
        public int DepartmentID { get; set; }
        public Department Departments { get; set; } = default!;

    }


 

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
    
    //DisCharge class Cut to out side


    
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [ForeignKey("PatientRegisters")]
        public int PatientID { get; set; }
        public string Transaction_Info { get; set; } = default!;
        public decimal Bill_Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Due { get; set; }
        public string PaymentMethod { get; set; } = default!;
        public string PaymentStatus { get; set; } = default!;
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; } = default!;
        public string BillingNotes { get; set; } = default!;
        public string PreparedBy { get; set; } = default!;

        public PatientRegister PatientRegisters { get; set; } = default!;
        public virtual ICollection<Outdoor> Outdoors { get; set; } = new List<Outdoor>();
    }
}
