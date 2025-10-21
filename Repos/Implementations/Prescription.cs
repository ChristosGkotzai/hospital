using hospital.Data;
using hospital.Models;
using hospital.Repos.Interface.Per;
using Microsoft.EntityFrameworkCore;

namespace hospital.Repo.Implement.Rep
{
    public class PrescriptionRepo : IPrescriptionRepo
    {
        private readonly AppDbContext _context;
        public PrescriptionRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Prescription>> GetAll()
        {
            return await _context.Prescriptions
                .Include(p => p.Appointment)
                .ThenInclude(a => a.Doctor)
                .Include(p => p.Appointment)
                .ThenInclude(a => a.Patient)
                .ToListAsync();
        }
        public async Task<Prescription?> GetById(int id)
        {
            return await _context.Prescriptions
                .Include(p => p.Appointment)
                .ThenInclude(a => a.Doctor)
                .Include(p => p.Appointment)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Prescription> Add(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }
        public async Task Update(Prescription prescription)
        {
            _context.Entry(prescription).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription is not null)
            {
                _context.Prescriptions.Remove(prescription);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Prescription?> GetByAppointmentId(int id)
        {
            return await _context.Prescriptions
                .Include(p => p.Appointment)
                .FirstOrDefaultAsync(p => p.AppointmentId == id);
        }
            
    }
}