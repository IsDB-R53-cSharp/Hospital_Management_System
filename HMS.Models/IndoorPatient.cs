using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Models
{
    public class IndoorPatient
    {
        [Key]
        public int IndoorPatientID { get; set; }

        public int PatientID { get; set; }
        public int WardID { get; set; }

        [ForeignKey("MedicalRecords")]
        public int? MedicalRecordsID { get; set; }

        public bool IsDead { get; set; }

        [StringLength(200)]
        [Display(Name = "Referred By")]
        public string ReferredBy { get; set; }

        [Display(Name = "Bed Number")]
        public int BedNumber { get; set; }

        public string NIDnumber { get; set; }

        [StringLength(500)]
        [Display(Name = "Insurance Information")]
        public string? InsuranceInfo { get; set; }

        [StringLength(500)]
        [Display(Name = "Admission Notes")]
        public string? AdmissionNotes { get; set; }


        // Navigation property for the patient
        [NotMapped]
        public virtual PatientRegister PatientRegisters { get; set; }

        // Navigation property for medical records
        [NotMapped]
        public virtual MedicalRecords MedicalRecords { get; set; }
    }
}
