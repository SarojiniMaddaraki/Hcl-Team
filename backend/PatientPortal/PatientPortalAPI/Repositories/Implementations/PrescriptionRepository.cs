using Microsoft.EntityFrameworkCore;
using PatientPortalAPI.Data;
using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Implementations
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly ApplicationDbContext _db;

        public PrescriptionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Prescription> AddAsync(Prescription prescription)
        {
            await _db.Prescriptions.AddAsync(prescription);
            await _db.SaveChangesAsync();
            return prescription;
        }

        public async Task<IEnumerable<Prescription>> GetByRecordIdAsync(int recordId)
        {
            return await _db.Prescriptions.Where(p => p.RecordID == recordId)
                                          .AsNoTracking()
                                          .ToListAsync();
        }
    }
}
