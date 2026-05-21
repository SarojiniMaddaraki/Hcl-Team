using Microsoft.AspNetCore.Mvc;
using PatientPortalAPI.Helpers;
using PatientPortalAPI.Models;
using PatientPortalAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace PatientPortalAPI.Controllers
{
    [ApiController]
    [Route("api/medicalrecord")]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly IMedicalRecordService _service;

        public MedicalRecordsController(IMedicalRecordService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get medical records for a patient
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatient(int patientId)
        {
            var list = await _service.GetByPatientIdAsync(patientId);
            return Ok(new ApiResponse { Success = true, Data = list });
        }

        /// <summary>
        /// Create medical record
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MedicalRecord record)
        {
            var created = await _service.CreateAsync(record);
            return CreatedAtAction(nameof(GetByPatient), new { patientId = created.PatientID }, new ApiResponse { Success = true, Data = created });
        }
    }
}
