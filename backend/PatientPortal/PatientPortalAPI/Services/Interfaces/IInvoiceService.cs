using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetByPatientIdAsync(int patientId);
        Task<Invoice> CreateAsync(Invoice invoice);
    }
}
