using hospital.Models;
using hospital.Repos.Interface.Doc;
using hospital.Services.Implement.IDocService;

namespace hospital.Services.Implement.Doc
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;

        public DoctorService(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }
        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _doctorRepo.GetAll();
        }
        public async Task<Doctor?> GetById(int id)
        {

            return await _doctorRepo.GetById(id);
        }
        public async Task<Doctor> Add(Doctor doctor)
        {
            return await _doctorRepo.Add(doctor);
        }
        public async Task<Doctor?> Update(int id, Doctor updatedDoctor)
        {
            var existing = await _doctorRepo.GetById(id);
            if (existing is null) return null;
            existing.FullName = updatedDoctor.FullName;
            existing.Speciality = updatedDoctor.Speciality;
            existing.Email = updatedDoctor.Email;
            await _doctorRepo.Update(existing);
            return existing;
        }
        public async Task<bool> Delete(int id)
        {
            var existing = await _doctorRepo.GetById(id);
            if (existing is null) return false;
            await _doctorRepo.Delete(id);
            return true;
        }
    }
}