using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using PatientPortalAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repo;

        public InvoiceService(IInvoiceRepository repo)
        {
            _repo = repo;
        }

        public async Task<Invoice> CreateAsync(Invoice invoice)
        {
            return await _repo.AddAsync(invoice);
        }

        public async Task<IEnumerable<Invoice>> GetByPatientIdAsync(int patientId)
        {
            return await _repo.GetByPatientIdAsync(patientId);
        }
    }
}
