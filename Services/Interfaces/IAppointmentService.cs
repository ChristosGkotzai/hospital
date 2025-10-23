using hospital.Models;

namespace hospital.Services.Interface.IAppoint
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAll();
        Task<Appointment?> GetById(int id);
        Task<Appointment> Add(Appointment appointment);
        Task<Appointment?> Update(int id, Appointment updatedappointment);
        Task<bool> Delete(int id);

        Task<IEnumerable<Appointment>> GetByDoctorId(int docId);
        Task<IEnumerable<Appointment>> GetByPatientId(int patId);
    }
}