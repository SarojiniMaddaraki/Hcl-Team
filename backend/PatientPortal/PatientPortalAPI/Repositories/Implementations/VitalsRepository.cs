using Microsoft.EntityFrameworkCore;
using PatientPortalAPI.Data;
using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Implementations
{
    public class VitalsRepository : IVitalsRepository
    {
        private readonly ApplicationDbContext _db;

        public VitalsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Vitals> AddAsync(Vitals vitals)
        {
            await _db.Vitals.AddAsync(vitals);
            await _db.SaveChangesAsync();
            return vitals;
        }

        public async Task<IEnumerable<Vitals>> GetByPatientIdAsync(int patientId)
        {
            return await _db.Vitals.Where(v => v.PatientID == patientId)
                                   .AsNoTracking()
                                   .ToListAsync();
        }
    }
}
