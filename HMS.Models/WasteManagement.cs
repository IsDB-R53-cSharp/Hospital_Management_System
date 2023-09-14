using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class WasteManagement
    {
        [Key]
        public int WasteID { get; set; }
        public string WasteType { get; set; } = default!;
        [Column(TypeName = "date"),
        Display(Name = "Disposal Date"),
        DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime DisposalDate { get; set; }
        public string DisposalMethod { get; set; } = default!;
        public int Quantity { get; set; }
        [Column(TypeName = "date"),
        Display(Name = "NextDelivery Date"),
        DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime NextDeliveryDate { get; set; }
        [Display(Name = "Phone No")]
        public string ContactNumber { get; set; } = default!;
    }
}
