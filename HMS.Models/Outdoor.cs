using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Outdoor
    {
        [Key]
        public int OutdoorID { get; set; }

        [ForeignKey("PatientRegister")]
        public int? PatientID { get; set; }
        public string TreatmentType { get; set; } //add enum

        [Column(TypeName = "date")]
        [Display(Name = "Join Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TreatmentDate { get; set; }

        public string TicketNumber { get; set; }

        public int InvoiceID { get; set; }// FK

        public int DoctorID { get; set; }

        public string Remarks { get; set; }

        public bool IsAdmissionRequired { get; set; }

        public virtual PatientRegister PatientRegister { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
