using hospital.Models;

namespace hospital.Services.Implement.IDocService
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor?> GetById(int id);
        Task<Doctor> Add(Doctor doctor);
        Task <Doctor?>Update(int id,Doctor updatedDoctor);
        Task <bool> Delete(int id);
    }
}