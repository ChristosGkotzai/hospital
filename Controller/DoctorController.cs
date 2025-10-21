using hospital.Models;
using hospital.Services.Implement.Doc;
using hospital.Services.Implement.IDocService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hospital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetById(int id)
        {
            var doctor = _doctorService.GetById(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Doctor updatedDoctor)
        {
            var result = await _doctorService.Update(id, updatedDoctor);
            if (result == null) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _doctorService.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Doctor>> Add(Doctor doctor)
        {
            if (string.IsNullOrWhiteSpace(doctor.FullName)) return BadRequest("Doctor name is required");
            var newDoc = await _doctorService.Add(doctor);
            return CreatedAtAction(nameof(GetById), new { id = newDoc.Id }, newDoc);
        }
    }
}