using hospital.Models;

namespace hospital.Repos.Interface.Appo
{
    public interface IAppointmentRepo
    {
        Task<IEnumerable<Appointment>> GetAll();
        Task<Appointment?> GetById(int id);
        Task<Appointment> Add(Appointment appointment);
        Task Update(Appointment appointment);
        Task Delete(int id);

        ///by doc or patient
        Task<IEnumerable<Appointment>> GetByDoctorId(int DoctorId);
        Task<IEnumerable<Appointment>> GetByPatientId(int PatientId);
        
    }
}