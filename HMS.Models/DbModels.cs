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


    public class Morgue
    {
        [Key]
        public int MorgueID { get; set; }
        public string DeceasedName { get; set; } = default!;
        public bool IsPatient { get; set; }
        public int PatientID { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string CauseOfDeath { get; set; } = default!;
    }
    public class Ambulance
    {
        [Key]
        public int AmbulanceID { get; set; }
        public string AmbulanceNumber { get; set; } = default!;
        //Driver Phone Number{Required}
        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = default!;
        public string DrivingLiense { get; set; } = default!;
        public string DriverName { get; set; } = default!;
        public string LastLocation { get; set; } = default!;
        public bool Availability { get; set; }
    }
    public class WasteManagement
    {
        [Key]
        public int WasteID { get; set; }
        public string WasteType { get; set; } = default!;
        public DateTime DisposalDate { get; set; }
        public string DisposalMethod { get; set; } = default!;
        public int Quantity { get; set; }
        public DateTime NextScheduleDate { get; set; }
        public string ContactNumber { get; set; } = default!;
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
    
    public class PatientRegister
    {
        [Key]
        public int PatientID { get; set; }
        public string PatientName { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string EmergencyContact { get; set; } = default!;
        public DateTime AdmissionDate { get; set; }
        public string BloodType { get; set; } = default!;
        public bool IsTransferred { get; set; }
        [ForeignKey("WardCabin")]
        public int WardID { get; set; }
        // add navigation properties
        public virtual WardCabin WardCabin { get; set; } = default!;
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public virtual ICollection<Prescriptions> Prescriptions { get; set; } = new List<Prescriptions>();
        public virtual ICollection<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();
        public virtual ICollection<SurgeryProcedure> SurgeryProcedures { get; set; } = new List<SurgeryProcedure>();
        public virtual ICollection<DischargeTransfer> DischargeTransfers { get; set; } = new List<DischargeTransfer>();
    }
    public class Prescriptions
    {
        [Key]
        public int PrescriptionID { get; set; }
        [ForeignKey("PatientRegister")]
        public int PatientID { get; set; }
        [ForeignKey("Medicine")]
        public int MedicinID { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Dosage { get; set; } = default!;
        public string Advice { get; set; } = default!;
        public string ProgressNotes { get; set; } = default!;
        public DateTime? NextVisit { get; set; } = default!; // Nullable
        public bool AdmissionSuggested { get; set; } = default!;
        //public string PrescribedBy { get; set; } //doctor name comes via DoctorID
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        [ForeignKey("LabTest")]
        public int TestID { get; set; }
        public DateTime DiagnosisDate { get; set; }//work as prescription date
        public string Symptoms { get; set; } = default!;
        public DateTime SymptomStartDate { get; set; }
        public int Severity { get; set; }
        public string Duration { get; set; } = default!;
        public string DiagonesNotes { get; set; } = default!;
        public string FollowUpInstructions { get; set; } = default!;

    }

    public class DischargeTransfer
    {
        [Key]
        public int DT_ID { get; set; }
        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public DateTime DischargeDate { get; set; }
        public string DischargeSummary { get; set; } = default!;

        public PatientRegister Patient { get; set; } = default!;
    }
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
