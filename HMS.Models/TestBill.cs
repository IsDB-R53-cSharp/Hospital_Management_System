using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class TestBill
    {
        [Key]
        public int TestBillID { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }  //only test korte asa lokder PrescriptionID nai, tai PatientID nilam. but ekta patient er old-new onek prescription thakbe. PatientID dile sob chole asbe na? 

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TB_Subtotal { get; set; }

        // Navigation properties

        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public virtual PatientRegister PatientRegisters { get; set; } // only need PatientID, then why virtual?
    }
}

//test id, name prescription theke jabe? naki TestID add hobe?
