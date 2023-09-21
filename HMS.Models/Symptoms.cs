using HMS.Models.SurgeryWard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Symptoms
    {
        [Key]
        public int SymptomsID { get; set; }

        [Required(ErrorMessage = "Please enter Symptoms Name")]
        [StringLength(200, ErrorMessage = "Please do not enter values over 200 characters")]
        public string SymptomsName { get; set; }
        [NotMapped]
        public virtual ICollection<Prescriptions>? Prescriptions { get; set; } = new List<Prescriptions>();
    }
}
