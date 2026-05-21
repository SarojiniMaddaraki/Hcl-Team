using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(int patientId);
        Task<MedicalRecord> CreateAsync(MedicalRecord record);
    }
}
