using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using PatientPortalAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Implementations
{
    public class LabResultService : ILabResultService
    {
        private readonly ILabResultRepository _repo;

        public LabResultService(ILabResultRepository repo)
        {
            _repo = repo;
        }

        public async Task<LabResult> CreateAsync(LabResult labResult)
        {
            return await _repo.AddAsync(labResult);
        }

        public async Task<IEnumerable<LabResult>> GetByPatientIdAsync(int patientId)
        {
            return await _repo.GetByPatientIdAsync(patientId);
        }
    }
}
