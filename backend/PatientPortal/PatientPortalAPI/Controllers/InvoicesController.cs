using Microsoft.AspNetCore.Mvc;
using PatientPortalAPI.Helpers;
using PatientPortalAPI.Models;
using PatientPortalAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace PatientPortalAPI.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoicesController(IInvoiceService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create invoice
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Invoice invoice)
        {
            var created = await _service.CreateAsync(invoice);
            return CreatedAtAction(nameof(GetByPatient), new { patientId = created.PatientID }, new ApiResponse { Success = true, Data = created });
        }

        /// <summary>
        /// Get invoices by patient
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatient(int patientId)
        {
            var list = await _service.GetByPatientIdAsync(patientId);
            return Ok(new ApiResponse { Success = true, Data = list });
        }
    }
}
