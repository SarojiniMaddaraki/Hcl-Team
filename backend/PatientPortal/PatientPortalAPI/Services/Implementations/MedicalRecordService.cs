using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using PatientPortalAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Implementations
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _repo;

        public MedicalRecordService(IMedicalRecordRepository repo)
        {
            _repo = repo;
        }

        public async Task<MedicalRecord> CreateAsync(MedicalRecord record)
        {
            return await _repo.AddAsync(record);
        }

        public async Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId)
        {
            return await _repo.GetByPatientIdAsync(patientId);
        }
    }
}
