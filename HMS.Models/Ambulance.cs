using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HMS.Models
{
    public class Ambulance
    {
        [Key]
        public int AmbulanceID { get; set; }
        [Required(ErrorMessage = "Please enter Ambulance Number")]
        [Display(Name = "Ambulance Number")]
        public string AmbulanceNumber { get; set; } = default!;
        //Driver Phone Number{Required}
        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Driver Phone Number")]
        public string PhoneNumber { get; set; } = default!;
        [Required(ErrorMessage = "Please enter Driving Liense")]
        [Display(Name = "Driving Liense")]
        public string DrivingLiense { get; set; } = default!;
        [Required(ErrorMessage = "Please enter Driver Name"),StringLength(50)]
        [Display(Name = "Driver Name")]
        public string DriverName { get; set; } = default!;
        [Required(ErrorMessage = "Please enter Last Location"), StringLength(200)]
        [Display(Name = "Last Location")]
        public string LastLocation { get; set; } = default!;
        public bool Availability { get; set; }
    }
}
