using hospital.Data;
using hospital.Models;
using hospital.Repos.Interface.Appo;
using Microsoft.EntityFrameworkCore;

namespace hospital.Repo.Implement.Appo
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly AppDbContext _context;
        public AppointmentRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _context.Appointments.ToListAsync();
        }
        public async Task<Appointment?> GetById(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<Appointment> Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task Update(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment is not null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<IEnumerable<Appointment>> GetByDoctorId(int id)
        {
            return await _context.Appointments
                .Where(a => a.DoctorId == id)
                .Include(b => b.Patient)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetByPatientId(int id)
        {
            return await _context.Appointments
                .Where(b => b.PatientId == id)
                .Include(c => c.Doctor)
                .ToListAsync();
        }

    }
}