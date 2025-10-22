using hospital.Models;

namespace hospital.Services.Interface.IPatientService
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAll();
        Task<Patient?> GetById(int id);
        Task<Patient> Add(Patient patient);
        Task <Patient?> Update(int id, Patient patient);
        Task <bool> Delete(int id);
    }
}
