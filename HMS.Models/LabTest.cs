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
    public class LabTest
    {
        [Key]
        public int TestID { get; set; }
        public string TestName { get; set; } = default!;

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        //[ForeignKey("Departments")]
        //public int DepartmentID { get; set; }
        //[ForeignKey("Doctor")]
        //public int DoctorID { get; set; }
        //[ForeignKey("PatientRegister")]
        public int? PatientID { get; set; }
        public string Result { get; set; } = default!;
        [ForeignKey("LabTechnician")]
        public int TechnicianID { get; set; }
        //nev
        [NotMapped]
        public virtual LabTechnician LabTechnician { get; set; } = default!;
        [NotMapped]
        public virtual PatientRegister? PatientRegister { get; set; } = default!;
        //public virtual Department Departments { get; set; } = default!;
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public virtual ICollection<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();
        public virtual ICollection<SurgeryProcedure> SurgeryProcedures { get; set; } = new List<SurgeryProcedure>();
    }
}
