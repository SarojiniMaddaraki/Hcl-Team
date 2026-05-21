using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace PatientPortalAPI.Models
{
    public class LabResult
    {
        [Key]
        public int LabID { get; set; }

        public int PatientID { get; set; }

        public string TestName { get; set; }

        public string Result { get; set; }

        public DateTime TestDate { get; set; }

        [JsonIgnore]
        public Patient? Patient { get; set; }
    }
}