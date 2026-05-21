using Microsoft.AspNetCore.SignalR.Protocol;

namespace PatientPortalAPI.Models
{
    public class Patient
    {
        public int PatientID { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        // Navigation Properties
        public ICollection<MedicalRecord> MedicalRecords { get; set; }

        public ICollection<LabResult> LabResults { get; set; }

        public ICollection<Vitals> Vitals { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
