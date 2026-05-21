using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace PatientPortalAPI.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionID { get; set; }


        public int RecordID { get; set; }

        public int DoctorID { get; set; }

        public string Medicine { get; set; }

        public string Dosage { get; set; }

        // Navigation Properties
        [ForeignKey("RecordID")]
        [JsonIgnore]
        public MedicalRecord? MedicalRecord { get; set; }

        [ForeignKey("DoctorID")]
        [JsonIgnore]
        public User? Doctor { get; set; }
    }
}
