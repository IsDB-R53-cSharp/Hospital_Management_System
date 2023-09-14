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
        //tray/or drawer Count
        //
        [Key]
        public int MorgueID { get; set; }
        [Required(ErrorMessage = "Enter Morgue Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string MorgueName { get; set; } = default!;
        //
        public ICollection<Drawer> Drawers { get; set; } = new List<Drawer>();
    }
}
