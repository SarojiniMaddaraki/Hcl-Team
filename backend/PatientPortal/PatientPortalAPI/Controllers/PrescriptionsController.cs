using Microsoft.AspNetCore.Mvc;
using PatientPortalAPI.Helpers;
using PatientPortalAPI.Models;
using PatientPortalAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace PatientPortalAPI.Controllers
{
    [ApiController]
    [Route("api/prescription")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _service;

        public PrescriptionsController(IPrescriptionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create prescription
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Prescription prescription)
        {
            var created = await _service.CreateAsync(prescription);
            return CreatedAtAction(nameof(GetByRecord), new { recordId = created.RecordID }, new ApiResponse { Success = true, Data = created });
        }

        /// <summary>
        /// Get prescriptions by medical record
        /// </summary>
        [HttpGet("record/{recordId}")]
        public async Task<IActionResult> GetByRecord(int recordId)
        {
            var list = await _service.GetByRecordIdAsync(recordId);
            return Ok(new ApiResponse { Success = true, Data = list });
        }
    }
}
