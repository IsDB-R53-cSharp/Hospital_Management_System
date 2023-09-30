﻿using HMS.Models.SurgeryWard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;

namespace HMS.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int DepartmentId { get; set; }
        [Required, MaxLength(100)]
        public string DepartmentName { get; set; } = default!;
        public string DepartmentDescription { get; set; } = default!;
        public virtual ICollection<Nurse> Nurses { get; set; } = new List<Nurse>();
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

        public virtual ICollection<WardCabin>? WardCabins { get; set; } = null;
        
        //= new List<WardCabin>();
        //public virtual ICollection<Test> Tests { get; set; }=new List<Test>();
    }
}
