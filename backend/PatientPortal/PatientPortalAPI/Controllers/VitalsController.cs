using Microsoft.AspNetCore.Mvc;
using PatientPortalAPI.Helpers;
using PatientPortalAPI.Models;
using PatientPortalAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace PatientPortalAPI.Controllers
{
    [ApiController]
    [Route("api/vitals")]
    public class VitalsController : ControllerBase
    {
        private readonly IVitalsService _service;

        public VitalsController(IVitalsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create vitals
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Vitals vitals)
        {
            var created = await _service.CreateAsync(vitals);
            return CreatedAtAction(nameof(GetByPatient), new { patientId = created.PatientID }, new ApiResponse { Success = true, Data = created });
        }

        /// <summary>
        /// Get vitals by patient
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatient(int patientId)
        {
            var list = await _service.GetByPatientIdAsync(patientId);
            return Ok(new ApiResponse { Success = true, Data = list });
        }
    }
}
