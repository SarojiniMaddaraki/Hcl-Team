using Microsoft.AspNetCore.Mvc;
using PatientPortalAPI.Helpers;
using PatientPortalAPI.Models;
using PatientPortalAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace PatientPortalAPI.Controllers
{
    [ApiController]
    [Route("api/labresult")]
    public class LabResultsController : ControllerBase
    {
        private readonly ILabResultService _service;

        public LabResultsController(ILabResultService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create lab result
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LabResult labResult)
        {
            var created = await _service.CreateAsync(labResult);
            return CreatedAtAction(nameof(GetByPatient), new { patientId = created.PatientID }, new ApiResponse { Success = true, Data = created });
        }

        /// <summary>
        /// Get lab results by patient
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatient(int patientId)
        {
            var list = await _service.GetByPatientIdAsync(patientId);
            return Ok(new ApiResponse { Success = true, Data = list });
        }
    }
}
