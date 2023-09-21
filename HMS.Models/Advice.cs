using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Advice
    {
        [Key]
        public int AdviceID { get; set; }

        [Required(ErrorMessage = "Please enter Advice")]
        [StringLength(250, ErrorMessage = "Please do not enter values over 250 characters")]
        public string AdviceName { get; set; }
        [NotMapped]
        public virtual ICollection<Prescriptions>? Prescriptions { get; set; } = new List<Prescriptions>();
    }
}
