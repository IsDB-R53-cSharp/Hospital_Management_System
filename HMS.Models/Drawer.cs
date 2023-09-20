using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Drawer
    {
        public int DrawerID { get; set; }
        [Display(Name = "Drawer No")]
        public string DrawerNo { get; set; } = default!;
        public int DrawerCount { get; set; }
        //nev
        public virtual ICollection<Morgue> Morgues { get; set; } = new List<Morgue>();
    }
}
