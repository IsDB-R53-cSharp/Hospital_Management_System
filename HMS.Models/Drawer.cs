using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Drawer
    {
        public int DrawerID { get; set; }

        [Display(Name = "Drawer Number")]
        public string DrawerNo { get; set; } = default!;

        [Display(Name = "Drawer Condition")]
        public DrawerCondition DrawerCondition { get; set; }

        public bool IsOccupied { get; set; }

        //Dead body info
        [Display(Name = "Name of Dead Person")]
        public string? DeceasedName { get; set; } = default!;

        public bool IsPatient { get; set; }

        public int? PatientID { get; set; }

        [Column(TypeName = "date"),
        Display(Name = "Date Of Death"),
        DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateOfDeath { get; set; }

        [StringLength(200, ErrorMessage = "Please do not enter values over 200 characters")]
        public string? CauseOfDeath { get; set; } = default!;

        [ForeignKey("Morgue")]
        public int MorgueID { get; set; }

        public virtual Morgue? Morgue { get; set; }
    }

    public enum DrawerCondition
    {
        [Display(Name = "Clean")]
        Clean = 1,

        [Display(Name = "Dirty")]
        Dirty,

        [Display(Name = "Under Maintenance")]
        UnderMaintenance,

        [Display(Name = "Out of Service")]
        OutOfService
    }
}
