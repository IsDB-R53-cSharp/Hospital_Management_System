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
        public string AmbulanceNumber { get; set; } = default!;
        //Driver Phone Number{Required}
        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = default!;
        public string DrivingLiense { get; set; } = default!;
        public string DriverName { get; set; } = default!;
        public string LastLocation { get; set; } = default!;
        public bool Availability { get; set; }
    }
}
