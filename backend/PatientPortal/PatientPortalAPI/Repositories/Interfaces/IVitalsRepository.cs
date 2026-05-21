using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Interfaces
{
    public interface IVitalsRepository
    {
        Task<IEnumerable<Vitals>> GetByPatientIdAsync(int patientId);
        Task<Vitals> AddAsync(Vitals vitals);
    }
}
