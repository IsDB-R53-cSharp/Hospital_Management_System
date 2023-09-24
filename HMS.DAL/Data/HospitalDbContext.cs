using HMS.Models;
using HMS.Models.SurgeryWard;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using LabTechnician = HMS.Models.LabTechnician;

namespace HMS.DAL.Data
{
    public class HospitalDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<Drawer> Drawers { get; set; }
        public DbSet<Morgue> Morgues { get; set; }
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<WasteManagement> WasteManagements { get; set; }
        //public DbSet<Department> Departments { get; set; }
        public DbSet<Department>? Departments { get; set; } = null;
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PatientRegister> PatientRegisters { get; set; }
        public DbSet<OtherEmployee> OtherEmployees { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<LabTechnician> LabTechnicians { get; set; }
        public DbSet<LabEquipment> LabEquipments { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Outdoor> Outdoors { get; set; }
        //public DbSet<Diagnoses> Diagnoses { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public DbSet<SurgeryProcedure> SurgeryProcedures { get; set; }
        public DbSet<DischargeTransfer> DischargeTransfers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WardCabin>? WardCabins { get; set; } = null;
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Advice> Advices { get; set; }




        //modelBuilder.Entity<PatientRegister>()
        // .HasMany(p => p.Prescriptions)
        //.WithOne()
        // .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<SurgeryProcedure>()
        //.HasOne(sp => sp.Prescription)
        //.WithMany()
        //.OnDelete(DeleteBehavior.Restrict);



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData.SeedDepartments(modelBuilder);
            SeedData.SeedWardCabins(modelBuilder);
            SeedData.SeedPatients(modelBuilder);
            SeedData.SeedDoctors(modelBuilder);
            SeedData.SeedNurses(modelBuilder);
            SeedData.SeedLabTechnicians(modelBuilder);
            SeedData.SeedOtherEmployees(modelBuilder);


            //for auth
            //modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            //modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            //modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            // or for auth

            base.OnModelCreating(modelBuilder);
        }

    }
}
