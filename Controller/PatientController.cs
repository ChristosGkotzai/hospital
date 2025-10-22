using hospital.Models;
using hospital.Repos.Interface.Pat;
using hospital.Services.Implement.Pat;
using hospital.Services.Interface.IPatientService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hospital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patService;
        public PatientController(IPatientService patService)
        {
            _patService = patService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAll()
        {
            var pats = await _patService.GetAll();
            return Ok(pats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetById(int id)
        {
            var pat = await _patService.GetById(id);
            if (pat == null) return NotFound();
            return Ok(pat);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Patient updatedpatient)
        {
            var result = await _patService.Update(id, updatedpatient);
            if (result == null) return NotFound();
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Patient>> Add(Patient patient)
        {
            if (string.IsNullOrWhiteSpace(patient.FullName)) return BadRequest();
            var newPat = await _patService.Add(patient);
            return CreatedAtAction(nameof(GetById), new { id = newPat.Id }, newPat);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _patService.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }

}