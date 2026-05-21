namespace PatientPortalAPI.Models
{
    public class LabResult
    {
        public int LabID { get; set; }

        public int PatientID { get; set; }

        public string TestName { get; set; }

        public string Result { get; set; }

        public DateTime TestDate { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }
    }
}
