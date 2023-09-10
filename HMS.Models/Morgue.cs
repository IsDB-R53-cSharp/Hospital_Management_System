using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Morgue
    {
        [Key]
        public int MorgueID { get; set; }
        public string DeceasedName { get; set; } = default!;
        public bool IsPatient { get; set; }
        public int PatientID { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string CauseOfDeath { get; set; } = default!;
    }
}
