using HMS.Models;
using HMS.Models.SurgeryWard;
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
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<Morgue> Morgues { get; set; }
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<WasteManagement> WasteManagements { get; set; }
        //public DbSet<Department> Departments { get; set; }
        public DbSet<Department>? Departments { get; set; } = null;
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PatientRegister>? PatientRegisters { get; set; } = null;
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
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<WardCabin>? WardCabins { get; set; } = null;

        

        //from mama to avoid exception
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .Property(i => i.Bill_Amount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Discount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.PaidAmount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Due)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<LabTest>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Medicine>()
                .Property(m => m.SellPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Department>().HasData(
               new Department
               {
                   DepartmentId = 1,
                   DepartmentName = "Neurology",
                   DepartmentDescription = "It is concerned with disorders and diseases of the nervous system"
               },
               new Department
               {
                   DepartmentId = 2,
                   DepartmentName = "Paediatrics",
                   DepartmentDescription = "The branch of medicine dealing with children and their diseases."
               }
               );
            modelBuilder.Entity<WardCabin>().HasData(
                new WardCabin
                {
                    WardID = 1,
                    WardName = "Neuro Care",
                    BedCabinNumber = 23,
                    DepartmentID = 1,
                },
                new WardCabin
                {
                    WardID = 2,
                    WardName = "Child Care",
                    BedCabinNumber = 40,
                    DepartmentID = 2,
                },
                new WardCabin
                {
                    WardID = 3,
                    WardName = "Nerve Care",
                    BedCabinNumber = 12,
                    DepartmentID = 1,
                }
                );


            modelBuilder.Entity<PatientRegister>().HasData(
                  new PatientRegister
                  {
                      PatientID = 1,
                      PatientName = "amina begum",
                      Gender = Gender.Female,
                      AdmissionDate = new DateTime(2023, 9, 5),
                      DateOfBirth = new DateTime(1999, 2, 12),
                      Address = "dhaka",
                      EmergencyContact="123456789",
                      Email = "am@gmail.com",
                      BloodType = BloodType.ABNegative,
                      IsTransferred = false,
                      Phone = "12345678",
                      WardID = 1

                  },
                   new PatientRegister
                   {
                       PatientID = 2,
                       PatientName = "Azman Mollah",
                       Gender = Gender.Male,
                       AdmissionDate = new DateTime(2023, 9, 2),
                       DateOfBirth = new DateTime(1971, 12, 16),
                       Address = "Pabna",
                       EmergencyContact = "123456789",
                       Email = "az@gmail.com",
                       BloodType = BloodType.ONegative,
                       IsTransferred = false,
                       Phone = "1233454",
                       WardID = 3

                   }

                  );

            modelBuilder.Entity<PatientRegister>()
             .HasMany(p => p.Prescriptions)
            .WithOne()
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurgeryProcedure>()
            .HasOne(sp => sp.Prescription)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);




        }

    }
}
