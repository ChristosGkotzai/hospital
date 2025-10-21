using hospital.Data;
using hospital.Models;
using hospital.Repos.Interface.Doc;
using Microsoft.EntityFrameworkCore;

namespace hospital.Repo.Implement.Doc
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly AppDbContext _context;
        public DoctorRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _context.Doctors.ToListAsync();//apo db tous doctor
        }
        public async Task<Doctor?> GetById(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task<Doctor> Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }
        public async Task Update(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor is not null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}