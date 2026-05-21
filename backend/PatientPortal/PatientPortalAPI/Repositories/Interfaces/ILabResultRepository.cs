using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Interfaces
{
    public interface ILabResultRepository
    {
        Task<IEnumerable<LabResult>> GetByPatientIdAsync(int patientId);
        Task<LabResult> AddAsync(LabResult labResult);
    }
}
