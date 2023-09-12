using HMS.Models.SurgeryWard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required(ErrorMessage = "Enter Patient Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string PatientName { get; set; } = default!;

        [Required, EnumDataType(typeof(BloodType))]
        public Gender Gender { get; set; }

        [Column(TypeName = "date"),
         Display(Name = "Admission Date"),
         DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime? AdmissionDate { get; set; } //must be nullable

        [AdmissionDateMustBeOnOrAfterBirthDateAttribute] // custom validation
        [Column(TypeName = "date"),
         Display(Name = "Patient BirthDate"),
         DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(200)]
        public string? EmergencyContact { get; set; } //Emargency person details. not only phone number. so string better. 

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email format is not valid.")]
        public string? Email { get; set; } = string.Empty;

        [EnumDataType(typeof(BloodType))]
        public BloodType? BloodType { get; set; }

        public bool? IsTransferred { get; set; }

        [ForeignKey("WardCabin")]
        public int? WardID { get; set; }

        // Navigation properties
        public virtual WardCabin? WardCabin { get; set; }

        public virtual ICollection<Bill?> Bills { get; set; } = new List<Bill?>();

        public virtual ICollection<Prescriptions?> Prescriptions { get; set; } = new List<Prescriptions?>();

        public virtual ICollection<MedicalRecords?> MedicalRecords { get; set; } = new List<MedicalRecords?>();

        public virtual ICollection<SurgeryProcedure?> SurgeryProcedures { get; set; } = new List<SurgeryProcedure?>();

        public virtual ICollection<DischargeTransfer?> DischargeTransfers { get; set; } = new List<DischargeTransfer?>();
    }
    public enum BloodType
    {
        [Description("A+")]
        APositive=1,

        [Description("A-")]
        ANegative,

        [Description("B+")]
        BPositive,

        [Description("B-")]
        BNegative,

        [Description("AB+")]
        ABPositive,

        [Description("AB-")]
        ABNegative,

        [Description("O+")]
        OPositive,

        [Description("O-")]
        ONegative
    }

    public enum Gender
    {
        [Description("Male")]
        Male=1,

        [Description("Female")]
        Female,

        [Description("Other")]
        Other,

        [Description("Prefer Not to Say")]
        PreferNotToSay
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class AdmissionDateMustBeOnOrAfterBirthDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var admissionDate = (DateTime?)value; //nullable DateTime cast korlam
            var birthDateProperty = validationContext.ObjectType.GetProperty("DateOfBirth");
            var birthDate = (DateTime?)birthDateProperty.GetValue(validationContext.ObjectInstance, null);

            if (admissionDate.HasValue && birthDate.HasValue && admissionDate.Value < birthDate.Value)
            {
                return new ValidationResult("Admission date must be on or after the birth date.");
            }

            return ValidationResult.Success;
        }
    }




    //old db model
    //public class PatientRegister
    //{
    //    [Key]
    //    public int PatientID { get; set; }
    //    public string PatientName { get; set; } = default!;
    //    public Gender Gender { get; set; }
    //    public DateTime DateOfBirth { get; set; }
    //    public string Address { get; set; } = default!;
    //    public string PhoneNumber { get; set; } = default!;
    //    public string Email { get; set; } = default!;
    //    public string EmergencyContact { get; set; } = default!;
    //    public DateTime AdmissionDate { get; set; }
    //    public string BloodType { get; set; } = default!;
    //    public bool IsTransferred { get; set; }
    //    [ForeignKey("WardCabin")]
    //    public int WardID { get; set; }
    //    // add navigation properties
    //    public virtual WardCabin WardCabin { get; set; } = default!;
    //    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    //    public virtual ICollection<Prescriptions> Prescriptions { get; set; } = new List<Prescriptions>();
    //    public virtual ICollection<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();
    //    public virtual ICollection<SurgeryProcedure> SurgeryProcedures { get; set; } = new List<SurgeryProcedure>();
    //    public virtual ICollection<DischargeTransfer> DischargeTransfers { get; set; } = new List<DischargeTransfer>();
    //}


}
