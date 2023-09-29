using Humanizer;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class ServiceBill
    {
        [Key]
        public int ServiceBillID { get; set; }

        public int ServiceCount { get; set; }  //ekta service koybar nise? (ex: doctor visit count)

        [ForeignKey("PatientRegister")]
        public int PatientID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SB_Subtotal { get; set; }

        // Navigation properties
        public virtual PatientRegister PatientRegister { get; set; } // need virtual?  I only need PatientID, not  ১৪ গুস্টি 🙄
        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
