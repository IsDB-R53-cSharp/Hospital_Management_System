using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }

        //[ForeignKey("PatientRegisters")]
        public int? PatientID { get; set; }

        [StringLength(500)]
        public string? TransactionInfo { get; set; } = default!;

        [Required, Range(0, Double.MaxValue, ErrorMessage = "Bill Amount must be greater than 0")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BillAmount { get; set; }

        [Range(0, 50, ErrorMessage = "Discount cannot be over 50%")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Discount { get; set; }

        [Required, Range(0, Double.MaxValue, ErrorMessage = "Paid Amount must be greater than 0")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidAmount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Due { get; set; }

        [Required]
        [EnumDataType(typeof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [EnumDataType(typeof(PaymentStatus))]
        public PaymentStatus PaymentStatus { get; set; } = default!;

        [Required,Column(TypeName = "date")]
        [Display(Name = "Treatment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BillDate { get; set; }

        public bool isInsurance { get; set; }

        [StringLength(500)]
        public string? InsuranceInfo { get; set; }

        [StringLength(200)]
        public string? BillingAddress { get; set; } = default!;

        [StringLength(500)]
        public string? BillingNotes { get; set; } = default!;

        [Required,StringLength(100)]
        public string PreparedBy { get; set; } = default!;

        // Navigation properties
        [ForeignKey("Service")]
        public int? ServiceID { get; set; }
        [NotMapped]
        public PatientRegister? PatientRegisters { get; set; } = default!;
        public virtual ICollection<Outdoor?> Outdoors { get; set; } = new List<Outdoor?>();
        public virtual Service? Service { get; set; } = default!;

        // Custom validation methods
        public IEnumerable<ValidationResult> ValidatePaidAmount(ValidationContext validationContext)
        {
            if (PaidAmount > BillAmount)
            {
                yield return new ValidationResult("Paid Amount cannot be greater than Bill Amount", new[] { nameof(PaidAmount) });
            }
        }

        public IEnumerable<ValidationResult> ValidateDueAmount(ValidationContext validationContext)
        {
            if (Due.HasValue && Due > 0.6m * BillAmount)
            {
                yield return new ValidationResult("Due Amount cannot exceed 60% of Bill Amount", new[] { nameof(Due) });
            }
        }
    }
    public enum PaymentMethod
    {
        [Display(Name = "Cash")]
        Cash = 0,

        [Display(Name = "Bank Card")]
        BankCard = 1,

        [Display(Name = "Bank Check")]
        BankCheck = 2,

        [Display(Name = "BKash")]
        BKash = 3,

        [Display(Name = "Rocket")]
        Rocket = 4,

        [Display(Name = "Nagad")]
        Nagad = 5,

        [Display(Name = "Foreign Currency")]
        ForeignCurrency = 6
    }

    public enum PaymentStatus
    {
        [Display(Name = "Paid")]
        Paid = 0,

        [Display(Name = "Due")]
        Due = 1,

        [Display(Name = "Waived")]
        Waived = 2
    }


    //old bill table -- hazera
    //public class Bill
    //{
    //    [Key]
    //    public int BillID { get; set; }
    //    [ForeignKey("PatientRegisters")]
    //    public int PatientID { get; set; }
    //    public string Transaction_Info { get; set; } = default!;
    //    public decimal Bill_Amount { get; set; }
    //    public decimal Discount { get; set; }
    //    public decimal PaidAmount { get; set; }
    //    public decimal Due { get; set; }
    //    public string PaymentMethod { get; set; } = default!;
    //    public string PaymentStatus { get; set; } = default!;
    //    public DateTime BillDate { get; set; }
    //    public string? BillingAddress { get; set; } = default!;
    //    public string? BillingNotes { get; set; } = default!;
    //    public string PreparedBy { get; set; } = default!;
    //    //nev
    //    [ForeignKey("Service")]
    //    public int ServiceID { get; set; }
    //    public PatientRegister PatientRegisters { get; set; } = default!;
    //    public virtual ICollection<Outdoor> Outdoors { get; set; } = new List<Outdoor>();
    //    public virtual Service Service { get; set; } = default!;
    //}
}
