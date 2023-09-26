using HMS.Models;
using System;

namespace Hospital_Management_System.Helpers
{
    public class OutdoorHelper
    {
        public int PatientID { get; set; }
        public TreatmentType TreatmentType { get; set; }
        public DateTime TreatmentDate { get; set; }
        public string TicketNumber { get; set; }
        //public int BillID { get; set; }
        //public int DoctorID { get; set; }
        public string? Remarks { get; set; }
        public bool IsAdmissionRequired { get; set; }

        public Outdoor GetOutdoor()
        {
            Outdoor outdoor = new Outdoor
            {
                PatientID = this.PatientID,
                TreatmentType = this.TreatmentType,
                TreatmentDate = this.TreatmentDate,
                TicketNumber = this.TicketNumber,
                //BillID = this.BillID,
                //DoctorID = this.DoctorID,
                Remarks = this.Remarks,
                IsAdmissionRequired = this.IsAdmissionRequired
            };

            return outdoor;
        }

        public void UpdateOutdoor(Outdoor existingOutdoor)
        {
            existingOutdoor.PatientID = this.PatientID;
            existingOutdoor.TreatmentType = this.TreatmentType;
            existingOutdoor.TreatmentDate = this.TreatmentDate;
            existingOutdoor.TicketNumber = this.TicketNumber;
            //existingOutdoor.BillID = this.BillID;
            //existingOutdoor.DoctorID = this.DoctorID;
            existingOutdoor.Remarks = this.Remarks;
            existingOutdoor.IsAdmissionRequired = this.IsAdmissionRequired;
        }
    }
}
