using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class MedicineBill
    {
        public int MedicineBillID { get; set; }

        [ForeignKey("Medicine")]
        public int MedicineID { get; set; }

        [ForeignKey("PatientRegister")]
        public int PatientID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MB_Subtotal { get; set; }

        //Nav
        //public  ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

        public ICollection<Medicine> Medicines { get; set; }
        public PatientRegister PatientRegister { get; set; }
    }
}
