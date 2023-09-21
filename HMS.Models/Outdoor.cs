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

        [EnumDataType(typeof(TreatmentType))]
        public TreatmentType TreatmentType { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Treatment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TreatmentDate { get; set; }

        [Display(Name = "Outdoor Ticket Number")]
        public string TicketNumber { get; set; } = default!;

        [ForeignKey("Bill")]
        public int BillID { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        public string Remarks { get; set; } = default!;

        public bool IsAdmissionRequired { get; set; }

        public virtual PatientRegister? PatientRegister { get; set; }

        public virtual Bill? Bill { get; set; }
    }
    public enum TreatmentType
    {
        [Display(Name = "Emergency")]
        Emergency = 1,

        [Display(Name = "Minor Treatment")]
        MinorTreatment,

        [Display(Name = "Vaccination")]
        Vaccination,

        [Display(Name = "Wound Dressing")]
        WoundDressing,

        [Display(Name = "Prescription Renewal")]
        PrescriptionRenewal,

        [Display(Name = "Physical Therapy")]
        PhysicalTherapy,

        [Display(Name = "Consultation")]
        Consultation,

        [Display(Name = "Follow-up")]
        FollowUp,

        [Display(Name = "Dental Checkup")]
        DentalCheckup,

        other
    }
}
