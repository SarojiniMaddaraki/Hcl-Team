using AutoMapper;
using PatientPortalAPI.DTOs;
using PatientPortalAPI.Models;
using PatientPortalAPI.Repositories.Interfaces;
using PatientPortalAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PatientDto> CreateAsync(PatientDto dto)
        {
            var entity = _mapper.Map<Patient>(dto);
            var created = await _repo.AddAsync(entity);
            return _mapper.Map<PatientDto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(p => _mapper.Map<PatientDto>(p));
        }

        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            return p == null ? null : _mapper.Map<PatientDto>(p);
        }

        public async Task<bool> UpdateAsync(int id, PatientDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);
            return true;
        }
    }
}
