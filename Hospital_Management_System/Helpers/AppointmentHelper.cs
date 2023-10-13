using HMS.Models.ViewModels;
using HMS.Models; // Add reference to HMS.Models if not already added
using System;

namespace Hospital_Management_System.Helpers
{
    public class AppointmentHelper
    {
        public int PatientID { get; set; }
        public HMS.Models.ViewModels.AppointmentType AppointmentType { get; set; }
        public DateTime AppointmentDate { get; set; }
        public HMS.Models.ViewModels.AppointmentStatus AppointmentStatus { get; set; }

        public string PatientName { get; set; }
        public string PatientIdentityNumber { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }

        public int DoctorID { get; set; }

        // Constructor to initialize properties from AppointmentVM
        public AppointmentHelper(AppointmentVM appointment)
        {
            PatientID = appointment.PatientID;
            AppointmentType = appointment.AppointmentType;
            AppointmentDate = appointment.AppointmentDate;
            AppointmentStatus = appointment.AppointmentStatus;
            PatientName = appointment.PatientName;
            PatientIdentityNumber = appointment.PatientIdentityNumber;
            Gender = appointment.Gender;
            PhoneNumber = appointment.PhoneNumber;
        }

        public AppointmentVM GetAppointmentVM()
        {
            var appointmentVM = new AppointmentVM
            {
                PatientID = this.PatientID,
                AppointmentType = this.AppointmentType,
                AppointmentDate = this.AppointmentDate,
                AppointmentStatus = this.AppointmentStatus,
                PatientName = this.PatientName,
                PatientIdentityNumber = this.PatientIdentityNumber,
                Gender = this.Gender,
                PhoneNumber = this.PhoneNumber,
                DoctorID = this.DoctorID,
            };

            return appointmentVM;
        }

        public void UpdateAppointmentVM(Appointment existingAppointment)
        {
            existingAppointment.PatientID = this.PatientID;
            existingAppointment.AppointmentType = (HMS.Models.AppointmentType)this.AppointmentType;
            existingAppointment.AppointmentDate = this.AppointmentDate;
            existingAppointment.AppointmentStatus = (HMS.Models.AppointmentStatus)this.AppointmentStatus;
            existingAppointment.DoctorID = this.DoctorID;
        }
    }
}
