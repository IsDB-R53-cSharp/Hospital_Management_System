using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime DisposalDate { get; set; }
        public string DisposalMethod { get; set; } = default!;
        public int Quantity { get; set; }
        public DateTime NextScheduleDate { get; set; }
        public string ContactNumber { get; set; } = default!;
    }
}
