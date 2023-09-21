﻿using System;
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
        [Display(Name = "Processing")]
        Processing=0,

        [Display(Name = "Cash")]
        Cash,

        [Display(Name = "Bank Card")]
        BankCard,

        [Display(Name = "Bank Check")]
        BankCheck,

        [Display(Name = "BKash")]
        BKash,

        [Display(Name = "Rocket")]
        Rocket,

        [Display(Name = "Nagad")]
        Nagad,

        [Display(Name = "Foreign Currency")]
        ForeignCurrency
    }

    public enum PaymentStatus
    {
        [Display(Name = "Due")]
        Due = 0,

        [Display(Name = "Paid")]
        Paid,

        [Display(Name = "Waived")]
        Waived
    }
}
