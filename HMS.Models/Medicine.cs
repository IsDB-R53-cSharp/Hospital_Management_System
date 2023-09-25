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
        Liquid = 1, Tablet, Capsules, Cream, Suppositories, Drops, Inhalers, Injection
    }
    public enum Strength
    {
        mg = 1, ml
    }
    public class Medicine
    {
        [Key]
        public int MedicineID { get; set; }
        public string MedicineName { get; set; } = default!;
        [EnumDataType(typeof(Strength))]
        public Strength Strength { get; set; }
        [EnumDataType(typeof(MedicineType))]
        public MedicineType MedicineType { get; set; }

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
        public virtual MedicineGeneric? MedicineGeneric { get; set; }
        [ForeignKey("Manufacturer")]
        public int ManufacturerID { get; set; } // Foreign key
        public virtual Manufacturer? Manufacturer { get; set; }
        [NotMapped]
        public virtual ICollection<Prescriptions>? Prescriptions { get; set; } = new List<Prescriptions?>();
    }
}
