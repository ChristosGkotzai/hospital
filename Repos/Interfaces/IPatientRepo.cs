using hospital.Models;

namespace hospital.Repos.Interface.Pat
{
    public interface IPatientRepo
    {
        Task<IEnumerable<Patient>> GetAll();
        Task<Patient?> GetById(int id);

        Task<Patient> Add(Patient patient);

        Task Update(Patient patient);
        Task Delete(int id);
    }
}