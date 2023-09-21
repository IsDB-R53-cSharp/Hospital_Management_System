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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<PatientRegister>().HasData(
                new PatientRegister
                {
                    PatientID = 1,
                    PatientName = "Sultana begum",
                    Gender = Gender.Female,
                    AdmissionDate = new DateTime(2023, 9, 5),
                    DateOfBirth = new DateTime(1999, 2, 12),
                    Address = "dhaka",
                    EmergencyContact = "123456789",
                    Email = "am@gmail.com",
                    BloodType = BloodType.ABNegative,
                    IsTransferred = true,
                    PhoneNumber = "12345678",
                    WardID = 1

                },
                new PatientRegister
                {
                    PatientID = 2,
                    PatientName = "Azman Mollah",
                    Gender = Gender.Male,
                    AdmissionDate = new DateTime(2023, 9, 2),
                    DateOfBirth = new DateTime(1971, 12, 16),
                    Address = "Sirajgonj",
                    EmergencyContact = "123456789",
                    Email = "az@gmail.com",
                    BloodType = BloodType.ONegative,
                    IsTransferred = false,
                    PhoneNumber = "1233454",
                    WardID = null

                }
            ));

            modelBuilder.Entity<Doctor>().HasData(
               new Doctor
               {
                   DoctorID = 1,
                   DoctorName = "Pipul Rahman",
                   DepartmentID = 1,
                   Specialization = "Cardiologist",
                   Doctortype = (doctortype)1,
                   JoinDate = DateTime.Parse("2023-01-15"),
                   ResignDate = null,
                   employeeStatus = (EmployeeStatus)1,
                   Education_Info = "MD in Cardiology from DMC University",
                   Image = "doctor1.jpg"
               },
               new Doctor
               {
                   DoctorID = 2,
                   DoctorName = "Ass Pina",
                   DepartmentID = 2,
                   Specialization = "Orthopedic Surgeon",
                   Doctortype = (doctortype)4,
                   JoinDate = DateTime.Parse("2023-02-20"),
                   ResignDate = null,
                   employeeStatus = (EmployeeStatus)1,
                   Education_Info = "MD in Orthopedics from ABC University",
                   Image = "doctor2.jpg"
               });

            modelBuilder.Entity<Nurse>().HasData(
                new Nurse
                {
                    NurseID = 1,
                    NurseName = "Sharmin Jahan",
                    DepartmentID = 1,
                    NurseType = (NurseType)1,
                    JoinDate = DateTime.Parse("2023-03-10"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)1,
                    Education_Info = "Bachelor of Science in Nursing",
                    Image = "nurse1.jpg"
                },
                new Nurse
                {
                    NurseID = 2,
                    NurseName = "Hafsa khatun",
                    DepartmentID = 2,
                    NurseType = (NurseType)2,
                    JoinDate = DateTime.Parse("2023-04-05"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)2,
                    Education_Info = "Licensed Practical Nurse Certification",
                    Image = "nurse2.jpg"
                });
            modelBuilder.Entity<LabTechnician>().HasData(
                new LabTechnician
                {
                    TechnicianID = 1,
                    TechnicianName = "valsun choudhury",
                    DepartmentID = 1,
                    TechnicianType = (TechnicianType)1,
                    JoinDate = DateTime.Parse("2023-05-15"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)1,
                    Education_Info = "Bachelor of Science in Medical Technology",
                    Image = "labtech1.jpg"
                },
                new LabTechnician
                {
                    TechnicianID = 2,
                    TechnicianName = "Robin mia",
                    DepartmentID = 2,
                    TechnicianType = (TechnicianType)2,
                    JoinDate = DateTime.Parse("2023-06-10"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)2,
                    Education_Info = "Certified Laboratory Technician",
                    Image = "labtech2.jpg"
                });

            modelBuilder.Entity<OtherEmployee>().HasData(
                new OtherEmployee
                {
                    EmployeeID = 1,
                    OtherEmployeeName = "abul mia",
                    OtherEmployeeType = (OtherEmployeeType)2,
                    JoinDate = DateTime.Parse("2023-07-20"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)1,
                    Education_Info = "JSC",
                    Image = "wordboy1.jpg"
                },
                new OtherEmployee
                {
                    EmployeeID = 2,
                    OtherEmployeeName = "ataur",
                    OtherEmployeeType = (OtherEmployeeType)6,
                    JoinDate = DateTime.Parse("2023-08-05"),
                    ResignDate = null,
                    employeeStatus = (EmployeeStatus)2,
                    Education_Info = "SSC",
                    Image = "driver1.jpg"
                });

            modelBuilder.Entity<PatientRegister>()
             .HasMany(p => p.Prescriptions)
            .WithOne()
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurgeryProcedure>()
            .HasOne(sp => sp.Prescription)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);



            //for auth
            //modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            //modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            //modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            // or for auth
            base.OnModelCreating(modelBuilder);

        }

    }
}
