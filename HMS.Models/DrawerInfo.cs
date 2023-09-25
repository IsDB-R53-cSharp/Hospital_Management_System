using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DrawerInfo
    {
        [Key]
        public int DrawerInfoID { get; set; }

        // Deadbody info
        public bool IsPatient { get; set; }

        [ForeignKey("Drawer")]
        public int DrawerID { get; set; }
        public virtual Drawer Drawer { get; set; }

        [ForeignKey("PatientRegister")]
        public int? PatientID { get; set; }
        public virtual PatientRegister? PatientRegister { get; set; }

        [ForeignKey("UnidentifiedDeadBody")]
        public int? UnidentifiedDeadBodyID { get; set; }
        public virtual UnidentifiedDeadBody? UnidentifiedDeadBody { get; set; }
    }


}
