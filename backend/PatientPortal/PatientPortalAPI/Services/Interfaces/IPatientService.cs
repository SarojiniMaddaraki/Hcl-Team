using PatientPortalAPI.DTOs;
using PatientPortalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientPortalAPI.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(int id);
        Task<PatientDto> CreateAsync(PatientDto dto);
        Task<bool> UpdateAsync(int id, PatientDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
