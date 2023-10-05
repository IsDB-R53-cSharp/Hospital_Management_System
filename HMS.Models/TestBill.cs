using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class TestBill
    {
        [Key]
        public int TestBillID { get; set; }

        [ForeignKey("Patient")]  //jsonignore
        public int PatientID { get; set; } // for test name

        //public string TestName { get; set; }
        //public int TestPrice { get; set; }

        [ForeignKey("Test")]  //jsonignore
        public int TestID { get; set; }   //for test price

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TB_Subtotal { get; set; }

        // Navigation properties

        public  ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public  PatientRegister PatientRegisters { get; set; } // only need PatientID, then why ?
    }
}
