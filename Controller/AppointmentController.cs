using hospital.Models;
using hospital.Services.Implement.Appo;
using hospital.Services.Interface.IAppoint;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hospital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appoService;

        public AppointmentController(IAppointmentService appoService)
        {
            _appoService = appoService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetById(int id)
        {
            var appointment = await _appoService.GetById(id);
            if (appointment == null) return NotFound();
            return Ok(appointment);
        }
        [HttpGet("doctor/{docId}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetByDoctorId(int docId)
        {
            var appo = await _appoService.GetByDoctorId(docId);
            if (appo == null) return NotFound();
            return Ok(appo);
        }
        [HttpGet("patient/{patId}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetByPatId(int patId)
        {
            var appo = await _appoService.GetByPatientId(patId);
            if (appo == null) return NotFound();
            return Ok(appo);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAll()
        {
            return Ok(await _appoService.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<Appointment>> Add(Appointment appointment)
        {
            if (appointment.DoctorId <= 0 || appointment.PatientId <= 0)
    return BadRequest("DoctorId and PatientId are required.");

            var newapp = await _appoService.Add(appointment);
            return CreatedAtAction(nameof(GetById), new { id = newapp.Id }, newapp);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _appoService.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Appointment updatedappointment)
        {
            var res = await _appoService.Update(id, updatedappointment);
            if (res == null) return NotFound();
            return NoContent();
        }
    }

}