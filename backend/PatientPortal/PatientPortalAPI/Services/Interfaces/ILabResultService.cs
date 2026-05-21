using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Interfaces
{
    public interface ILabResultService
    {
        Task<IEnumerable<LabResult>> GetByPatientIdAsync(int patientId);
        Task<LabResult> CreateAsync(LabResult labResult);
    }
}
