using hospital.Data;
using hospital.Models;
using hospital.Repos.Interface.Pat;
using Microsoft.EntityFrameworkCore;

namespace hospital.Repo.Implement.Pat
{
    public class PatientRepo : IPatientRepo
    {
        private readonly AppDbContext _context;

        public PatientRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _context.Patients.ToListAsync();
        }
        public async Task<Patient?> GetById(int id)
        {
            return await _context.Patients.FindAsync(id);
        }
        public async Task<Patient> Add(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
        public async Task Update(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient is not null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}