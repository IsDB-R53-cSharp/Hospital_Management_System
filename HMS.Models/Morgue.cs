using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Morgue
    {
        [Key]
        public int MorgueID { get; set; }
        [Required(ErrorMessage = "Enter Morgue Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string MorgueName { get; set; } = default!;
        //
        [ForeignKey("Drawer")]
        public int DrawerId { get; set; }
        public virtual Drawer? Drawer { get; set; }
    }
}
