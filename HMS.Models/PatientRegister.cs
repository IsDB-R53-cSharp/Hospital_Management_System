using HMS.Models.SurgeryWard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
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
}
