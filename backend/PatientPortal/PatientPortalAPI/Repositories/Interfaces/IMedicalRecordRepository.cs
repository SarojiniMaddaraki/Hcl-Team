using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Interfaces
{
    public interface IMedicalRecordRepository
    {
        Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId);
        Task<MedicalRecord> GetByIdAsync(int id);
        Task<MedicalRecord> AddAsync(MedicalRecord record);
    }
}
