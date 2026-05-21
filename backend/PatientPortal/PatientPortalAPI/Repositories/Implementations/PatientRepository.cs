using Microsoft.EntityFrameworkCore;
using PatientPortalAPI.Data;
using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Implementations
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Patient> AddAsync(Patient patient)
        {
            await _db.Patients.AddAsync(patient);
            await _db.SaveChangesAsync();
            return patient;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Patients.FindAsync(id);
            if (entity != null)
            {
                _db.Patients.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _db.Patients.AsNoTracking().ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _db.Patients.Include(p => p.MedicalRecords)
                                      .Include(p => p.LabResults)
                                      .Include(p => p.Vitals)
                                      .Include(p => p.Invoices)
                                      .FirstOrDefaultAsync(p => p.PatientID == id);
        }

        public async Task UpdateAsync(Patient patient)
        {
            _db.Patients.Update(patient);
            await _db.SaveChangesAsync();
        }
    }
}
