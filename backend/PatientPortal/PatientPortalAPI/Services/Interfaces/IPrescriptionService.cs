using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<Prescription>> GetByRecordIdAsync(int recordId);
        Task<Prescription> CreateAsync(Prescription prescription);
    }
}
