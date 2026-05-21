namespace PatientPortalAPI.DTOs
{
    public class PatientDto
    {
        public int PatientID { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
