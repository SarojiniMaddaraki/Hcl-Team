using Microsoft.EntityFrameworkCore;
using PatientPortalAPI.Data;
using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Implementations
{
    public class LabResultRepository : ILabResultRepository
    {
        private readonly ApplicationDbContext _db;

        public LabResultRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<LabResult> AddAsync(LabResult labResult)
        {
            await _db.LabResults.AddAsync(labResult);
            await _db.SaveChangesAsync();
            return labResult;
        }

        public async Task<IEnumerable<LabResult>> GetByPatientIdAsync(int patientId)
        {
            return await _db.LabResults
                .Where(l => l.PatientID == patientId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
