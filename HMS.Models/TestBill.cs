using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class TestBill
    {
        [Key]
        public int TestBillID { get; set; }


        public int TestID { get; set; }
        public int PatientID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TestPrice { get; set; }

        [ForeignKey("Bill")]
        public int BillID { get; set; }

        // Navigation property for Bill
        public virtual Bill Bill { get; set; }
    }
}
