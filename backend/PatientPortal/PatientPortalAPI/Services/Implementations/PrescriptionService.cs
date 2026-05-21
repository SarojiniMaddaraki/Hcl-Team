using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using PatientPortalAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Implementations
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _repo;

        public PrescriptionService(IPrescriptionRepository repo)
        {
            _repo = repo;
        }

        public async Task<Prescription> CreateAsync(Prescription prescription)
        {
            return await _repo.AddAsync(prescription);
        }

        public async Task<IEnumerable<Prescription>> GetByRecordIdAsync(int recordId)
        {
            return await _repo.GetByRecordIdAsync(recordId);
        }
    }
}
