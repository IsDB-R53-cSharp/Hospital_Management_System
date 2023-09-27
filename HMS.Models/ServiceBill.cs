using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class ServiceBill
    {
        [Key]
        public int ServiceBillID { get; set; }

        // Other service-related bill properties
        public int ServiceID { get; set; }
        public int PatientID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ServicePrice { get; set; }

        [ForeignKey("Bill")]
        public int BillID { get; set; }

        // Navigation property for Bill
        public virtual Bill Bill { get; set; }
    }
}
