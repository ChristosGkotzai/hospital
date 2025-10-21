using hospital.Models;
namespace hospital.Repos.Interface.Per
{
    public interface IPrescriptionRepo
    {
        Task<IEnumerable<Prescription>> GetAll();
        Task<Prescription?> GetById(int id);
        Task<Prescription> Add(Prescription prescription);
        Task Update(Prescription prescription);
        Task Delete(int id);

        Task<Prescription?> GetByAppointmentId(int id);

    }
}