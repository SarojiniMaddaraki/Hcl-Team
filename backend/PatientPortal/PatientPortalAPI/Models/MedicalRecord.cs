using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace PatientPortalAPI.Models
{
    public class MedicalRecord
    {
        [Key]
        public int RecordID { get; set; }

        public int PatientID { get; set; }

        public string Diagnosis { get; set; }

        public string Treatment { get; set; }

        public DateTime VisitDate { get; set; }

        // Navigation Property
        [JsonIgnore]
        public Patient? Patient { get; set; }

        [JsonIgnore]
        public ICollection<Prescription>? Prescriptions { get; set; }
    }
}
