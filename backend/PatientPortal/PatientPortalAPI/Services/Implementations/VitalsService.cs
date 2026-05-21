using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using PatientPortalAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Implementations
{
    public class VitalsService : IVitalsService
    {
        private readonly IVitalsRepository _repo;

        public VitalsService(IVitalsRepository repo)
        {
            _repo = repo;
        }

        public async Task<Vitals> CreateAsync(Vitals vitals)
        {
            return await _repo.AddAsync(vitals);
        }

        public async Task<IEnumerable<Vitals>> GetByPatientIdAsync(int patientId)
        {
            return await _repo.GetByPatientIdAsync(patientId);
        }
    }
}
