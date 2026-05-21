using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Repositories.Interfaces
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetByRecordIdAsync(int recordId);
        Task<Prescription> AddAsync(Prescription prescription);
    }
}
