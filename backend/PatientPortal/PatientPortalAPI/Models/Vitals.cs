using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace PatientPortalAPI.Models
{
    public class Vitals
    {
        [Key]
        public int VitalID { get; set; }

        public int PatientID { get; set; }

        public int NurseID { get; set; }

        public string BP { get; set; }

        public decimal Temperature { get; set; }

        public int Pulse { get; set; }

        public DateTime RecordedAt { get; set; }

        // Navigation Properties
        [JsonIgnore]
        public Patient? Patient { get; set; }

        [JsonIgnore]
        public User? Nurse { get; set; }
    }
}
