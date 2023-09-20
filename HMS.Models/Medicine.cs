using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public enum MedicineType
    {
        Liquid=1, Tablet,Capsules,Cream,Suppositories,Drops,Inhalers,Injections
    }
    public class Medicine
    {
        [Key]
        public int MedicineID { get; set; }
        public string MedicineName { get; set; } = default!;
        public MedicineType MedicineType { get; set; }
        public string Strength { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellPrice { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }
        [ForeignKey("MedicineGeneric")]
        public int MedicineGenericID { get; set; } // Foreign key
        public virtual MedicineGeneric MedicineGeneric { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerID { get; set; } // Foreign key
        public virtual Manufacturer Manufacturer { get; set; }
    }

    public class MedicineGeneric
    {
        [Key]
        public int MedicineGenericID { get; set; }
        public string MedicineGenericNames { get; set; } = default!;       
    }

    public class Manufacturer
    {
        [Key]
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; } = default!;
    }
    //check edit
}
