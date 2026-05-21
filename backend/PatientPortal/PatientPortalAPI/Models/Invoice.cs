using System.Text.Json.Serialization;
namespace PatientPortalAPI.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }

        public int PatientID { get; set; }

        public decimal Amount { get; set; }

        public string Status { get; set; }

        public DateTime GeneratedDate { get; set; }

        // Navigation Property
        [JsonIgnore]
        public Patient? Patient { get; set; }
    }
}
