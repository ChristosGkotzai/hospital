using hospital.Models;

namespace hospital.Repos.Interface.Doc
{
    public interface IDoctorRepo
    {
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor?> GetById(int id);
        Task<Doctor> Add(Doctor doctor);
        Task Update(Doctor doctor);
        Task  Delete(int id);
    }
}
