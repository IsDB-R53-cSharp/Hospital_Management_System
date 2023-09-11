using HMS.Models.SurgeryWard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HMS.Models
{
    public class Prescriptions
    {
        [Key]
        public int PrescriptionID { get; set; }
        [ForeignKey("PatientRegister")]
        public int PatientID { get; set; }
        [ForeignKey("Medicine")]
        public int MedicinID { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        [ForeignKey("LabTest")]
        public int TestID { get; set; }


        [Required]
        [Column(TypeName = "date"),
        Display(Name = "Prescription Date"),
        DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime PrescriptionDate { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "Please enter Dosage")]
        [StringLength(250, ErrorMessage = "Please do not enter values over 250 characters")]
        public string Dosage { get; set; } = default!;

        [Required(ErrorMessage = "Please enter Advice")]
        [StringLength(250, ErrorMessage = "Please do not enter values over 250 characters")]
        public string Advice { get; set; } = default!;


        [Required(ErrorMessage = "Please enter Progress Notes")]
        [StringLength(250, ErrorMessage = "Please do not enter values over 250 characters")]
        [Display(Name = "Progress Notes")]
        public string ProgressNotes { get; set; } = default!;

        private DateTime? _nextVisit;
        [Column(TypeName = "date")]
        [Display(Name = "Next Visit Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NextVisit
        {
            get
            {

                if (_nextVisit.HasValue && _nextVisit < PrescriptionDate)
                {
                    return PrescriptionDate;
                }
                return _nextVisit;
            }
            set { _nextVisit = value; }
        }
        // Nullable



        [Display(Name = "Admission Suggested")]
        public bool AdmissionSuggested { get; set; } = default!;
        //public string PrescribedBy { get; set; } //doctor name comes via DoctorID
        [Column(TypeName = "date"),
        Display(Name = "Diagnosis Date"),
        DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime? DiagnosisDate { get; set; }//work as prescription date


        [Required(ErrorMessage = "Please enter Symptoms")]
        [StringLength(200, ErrorMessage = "Please do not enter values over 200 characters")]
        public string Symptoms { get; set; } = default!;
        [Required]
        [Column(TypeName = "date"),
         Display(Name = "SymptomStart Date"),
         DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime SymptomStartDate { get; set; }
        [Required(ErrorMessage = "Please enter severity"), Range(0, 100)]
        [Display(Name = "Severity")]
        public int Severity { get; set; }
        [Required(ErrorMessage = "Please enter duration")]
        [StringLength(55, ErrorMessage = "Please do not enter values over 55 characters")]
        public string Duration { get; set; } = default!;
        [Required(ErrorMessage = "Please enter diagonesNotes")]
        [StringLength(200, ErrorMessage = "Please do not enter values over 200 characters")]
        public string DiagonesNotes { get; set; } = default!;
        [Required(ErrorMessage = "Please enter follow up instructions")]
        [StringLength(200, ErrorMessage = "Please do not enter values over 200 characters")]
        [Display(Name = "Follow Up Instructions")]
        public string FollowUpInstructions { get; set; } = default!;

        [NotMapped]
        public virtual Medicine? Medicine { get; set; } = default!;
        public virtual PatientRegister? PatientRegister { get; set; } = default!;
        public virtual Doctor? Doctor { get; set; } = default!;
        public virtual LabTest? LabTest { get; set; } = default!;
        public virtual ICollection<MedicalRecords>? MedicalRecords { get; set; } = new List<MedicalRecords>();
        public virtual ICollection<SurgeryProcedure>? SurgeryProcedures { get; set; } = new List<SurgeryProcedure>();
    }
}
