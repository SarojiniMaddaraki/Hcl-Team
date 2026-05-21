namespace PatientPortalAPI.Models
{
    public class MedicalRecord
    {
        public int RecordID { get; set; }

        public int PatientID { get; set; }

        public string Diagnosis { get; set; }

        public string Treatment { get; set; }

        public DateTime VisitDate { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
