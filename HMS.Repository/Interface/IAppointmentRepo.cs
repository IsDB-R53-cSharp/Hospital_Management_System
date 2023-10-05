using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IAppointmentRepo
    {
        Appointment GetAppointmentById(int appointmentID);
        IEnumerable<Appointment> GetAppointmentsForDoctor(int doctorID);
        IEnumerable<Appointment> GetAppointmentsByPatientName(string patientName);
        IEnumerable<Appointment> GetAppointmentsByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Appointment> GetAppointmentsByType(string appointmentType);
        IEnumerable<Appointment> GetAppointmentsByStatus(bool appointmentStatus);
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int appointmentID);
    }

}
