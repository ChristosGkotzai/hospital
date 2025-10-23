using hospital.Models;
using hospital.Repo.Implement.Appo;
using hospital.Repos.Interface.Appo;
using hospital.Services.Interface.IAppoint;
using Microsoft.AspNetCore.Http.HttpResults;

namespace hospital.Services.Implement.Appo
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo _appoRepo;
        public AppointmentService(IAppointmentRepo appoRepo)
        {
            _appoRepo = appoRepo;
        }
        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _appoRepo.GetAll();
        }
        public async Task<Appointment?> GetById(int id)
        {
            return await _appoRepo.GetById(id);
        }
        public async Task<Appointment> Add(Appointment appointment)
        {
            return await _appoRepo.Add(appointment);
        }
        public async Task<Appointment?> Update(int id, Appointment updatedappointment)
        {
            var existing = await _appoRepo.GetById(id);
            if (existing is null) return null;
            existing.AppointmentDate = updatedappointment.AppointmentDate;
            existing.DoctorId = updatedappointment.DoctorId;
            existing.PatientId = updatedappointment.PatientId;
            existing.Notes = updatedappointment.Notes;
            existing.Status = updatedappointment.Status;
            await _appoRepo.Update(existing);
            return existing;
        }
        public async Task<bool> Delete(int id)
        {
            var success = await _appoRepo.GetById(id);
            if (success is null) return false;
            await _appoRepo.Delete(id);
            return true;
        }
        public async Task<IEnumerable<Appointment>> GetByDoctorId(int id)
        {
            var appoitnmets = await _appoRepo.GetByDoctorId(id);
            return appoitnmets;
        }
        public async Task<IEnumerable<Appointment>> GetByPatientId(int id)
        {
            var appoitnmets = await _appoRepo.GetByPatientId(id);
            return appoitnmets;
        }
    }

}