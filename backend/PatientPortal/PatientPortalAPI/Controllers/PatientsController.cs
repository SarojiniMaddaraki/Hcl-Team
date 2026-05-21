using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientPortalAPI.DTOs;
using PatientPortalAPI.Helpers;
using PatientPortalAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace PatientPortalAPI.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(new ApiResponse { Success = true, Data = list });
        }

        /// <summary>
        /// Get patient by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var p = await _service.GetByIdAsync(id);
            if (p == null) return NotFound(new ApiResponse { Success = false, Message = "Not found" });
            return Ok(new ApiResponse { Success = true, Data = p });
        }

        /// <summary>
        /// Create patient
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.PatientID }, new ApiResponse { Success = true, Data = created });
        }

        /// <summary>
        /// Update patient
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientDto dto)
        {
            var ok = await _service.UpdateAsync(id, dto);
            if (!ok) return NotFound(new ApiResponse { Success = false, Message = "Not found" });
            return NoContent();
        }

        /// <summary>
        /// Delete patient
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound(new ApiResponse { Success = false, Message = "Not found" });
            return NoContent();
        }
    }
}
