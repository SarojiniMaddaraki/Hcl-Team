namespace PatientPortalAPI.Models
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }

        public int RecordID { get; set; }

        public int DoctorID { get; set; }

        public string Medicine { get; set; }

        public string Dosage { get; set; }

        // Navigation Properties
        public MedicalRecord MedicalRecord { get; set; }

        public User Doctor { get; set; }
    }
}
