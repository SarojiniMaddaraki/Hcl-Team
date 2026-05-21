using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetByPatientIdAsync(int patientId);
        Task<Invoice> AddAsync(Invoice invoice);
    }
}
