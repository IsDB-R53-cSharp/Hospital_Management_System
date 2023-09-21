using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Test
    {
        public int TestsID { get; set; }
        public string TestName { get; set; }
        public virtual ICollection<Prescriptions>? Prescriptions { get; set; } = new List<Prescriptions>();
    }
}
