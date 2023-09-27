using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class PrescriptionBill
    {
        [Key]
        public int PrescriptionBillID { get; set; }

        // Other prescription-related bill properties
        public int PrescriptionID { get; set; }
        public int PatientID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DoctorFee { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MedicinePrice { get; set; }

        [ForeignKey("Bill")]
        public int BillID { get; set; }

        // Navigation property for Bill
        public virtual Bill Bill { get; set; }
    }
}
