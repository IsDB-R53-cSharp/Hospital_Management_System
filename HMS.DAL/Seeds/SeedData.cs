using HMS.Models.SurgeryWard;
using HMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Data
{
    public static class SeedData
    {
        public static void SeedDepartments(ModelBuilder modelBuilder)
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
        }

        public static void SeedWardCabins(ModelBuilder modelBuilder)
        {
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
                }
            );
        }

        public static void SeedPatients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientRegister>().HasData(
                new PatientRegister
                {
                    PatientID = 1,
                    PatientName = "Sultana begum",
                    Gender = Gender.Female,
                    Address = "dhaka",
                    Email = "am@gmail.com",
                    PhoneNumber = "12345678",
                },
                new PatientRegister
                {
                    PatientID = 2,
                    PatientName = "Azman Mollah",
                    Gender = Gender.Male,
                    Address = "Sirajgonj",
                    Email = "az@gmail.com",
                    PhoneNumber = "1233454",
                }
            );
        }

        public static void SeedDoctors(ModelBuilder modelBuilder)
        {
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
                    PhoneNumber = "01917123456",
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
                    PhoneNumber = "01517123456",
                    Image = "doctor2.jpg"
                }
            );
        }

        public static void SeedNurses(ModelBuilder modelBuilder)
        {
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
                    PhoneNumber = "01317123456",
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
                    PhoneNumber = "01817123456",
                    Image = "nurse2.jpg"
                }
            );
        }

        public static void SeedLabTechnicians(ModelBuilder modelBuilder)
        {
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
                    PhoneNumber = "01617123456",
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
                    PhoneNumber = "01917123456",
                    Image = "labtech2.jpg"
                }
            );
        }

        public static void SeedOtherEmployees(ModelBuilder modelBuilder)
        {
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
                    PhoneNumber = "01917123456",
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
                    PhoneNumber = "01517123456",
                    Image = "driver1.jpg"
                }
            );
        }
        public static void SeedServices(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
                new Service { ServiceID = 1, ServiceName = "Bed charge", ServiceCharge = 500 },
                new Service { ServiceID = 2, ServiceName = "Cabin charge", ServiceCharge = 1500 },
                new Service { ServiceID = 3, ServiceName = "ICU charge", ServiceCharge = 3000 },
                new Service { ServiceID = 4, ServiceName = "Oxygen charge (per liter)", ServiceCharge = 120 },
                new Service { ServiceID = 5, ServiceName = "Food (per time)", ServiceCharge = 200 },
                new Service { ServiceID = 6, ServiceName = "Wound Dressing", ServiceCharge = 100 },
                new Service { ServiceID = 7, ServiceName = "Injection Pushing", ServiceCharge = 50 },
                new Service { ServiceID = 8, ServiceName = "Outdoor Doctor Visit", ServiceCharge = 500 },
                new Service { ServiceID = 9, ServiceName = "Indoor Doctor Visit (Assistant Professor)", ServiceCharge = 800 },
                new Service { ServiceID = 10, ServiceName = "Indoor Doctor Visit (Associate Professor)", ServiceCharge = 1200 },
                new Service { ServiceID = 11, ServiceName = "Indoor Doctor Visit (Professor)", ServiceCharge = 1500 },
                new Service { ServiceID = 12, ServiceName = "Room Cleaning", ServiceCharge = 100 },
                new Service { ServiceID = 13, ServiceName = "Patient Cleaning", ServiceCharge = 50 },
                new Service { ServiceID = 14, ServiceName = "Physical Therapy", ServiceCharge = 300 },
                new Service { ServiceID = 15, ServiceName = "Ambulance charge", ServiceCharge = 1000 },
                new Service { ServiceID = 16, ServiceName = "Morgue charge", ServiceCharge = 500 },
                new Service { ServiceID = 17, ServiceName = "Cloth Fee (Hospital Gown)", ServiceCharge = 100 },
                new Service { ServiceID = 18, ServiceName = "Orthopedic Device charge (crutches, wheelchair)", ServiceCharge = 250 },
                new Service { ServiceID = 19, ServiceName = "Pathological Sample Collection Fee (from Bed/Home)", ServiceCharge = 200 },
                new Service { ServiceID = 20, ServiceName = "Counseling fee", ServiceCharge = 400 },
                new Service { ServiceID = 21, ServiceName = "Rehabilitation fee", ServiceCharge = 400 }
            );
        }

    }
}
