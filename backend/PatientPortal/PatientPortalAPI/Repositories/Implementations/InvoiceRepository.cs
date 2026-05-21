using Microsoft.EntityFrameworkCore;
using PatientPortalAPI.Data;
using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Implementations
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _db;

        public InvoiceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Invoice> AddAsync(Invoice invoice)
        {
            await _db.Invoices.AddAsync(invoice);
            await _db.SaveChangesAsync();
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetByPatientIdAsync(int patientId)
        {
            return await _db.Invoices.Where(i => i.PatientID == patientId)
                                     .AsNoTracking()
                                     .ToListAsync();
        }
    }
}
