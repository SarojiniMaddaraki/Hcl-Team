namespace PatientPortalAPI.Models
{
    public class Vitals
    {
        public int VitalID { get; set; }

        public int PatientID { get; set; }

        public int NurseID { get; set; }

        public string BP { get; set; }

        public decimal Temperature { get; set; }

        public int Pulse { get; set; }

        public DateTime RecordedAt { get; set; }

        // Navigation Properties
        public Patient Patient { get; set; }

        public User Nurse { get; set; }
    }
}
