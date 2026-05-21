using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Interfaces
{
    public interface IVitalsService
    {
        Task<IEnumerable<Vitals>> GetByPatientIdAsync(int patientId);
        Task<Vitals> CreateAsync(Vitals vitals);
    }
}
