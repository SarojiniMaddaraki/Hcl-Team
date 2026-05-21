using Microsoft.EntityFrameworkCore;
using PatientPortalAPI.Data;
using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Implementations
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly ApplicationDbContext _db;

        public MedicalRecordRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<MedicalRecord> AddAsync(MedicalRecord record)
        {
            await _db.MedicalRecords.AddAsync(record);
            await _db.SaveChangesAsync();
            return record;
        }

        public async Task<MedicalRecord> GetByIdAsync(int id)
        {
            return await _db.MedicalRecords.Include(r => r.Prescriptions)
                                           .FirstOrDefaultAsync(r => r.RecordID == id);
        }

        public async Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId)
        {
            return await _db.MedicalRecords.Where(r => r.PatientID == patientId)
                                           .AsNoTracking()
                                           .ToListAsync();
        }
    }
}
