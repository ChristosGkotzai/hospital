using hospital.Models;
using hospital.Repos.Interface.Pat;
using hospital.Services.Interface.IPatientService;
using Microsoft.AspNetCore.Http.HttpResults;


namespace hospital.Services.Implement.Pat
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepo;

        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _patientRepo.GetAll();
        }
        public async Task<Patient?> GetById(int id)
        {
            return await _patientRepo.GetById(id);
        }

        public async Task<Patient> Add(Patient patient)
        {
            return await _patientRepo.Add(patient);
        }

        public async Task<Patient?> Update(int id, Patient updatedpatient)
        {
            var existing = await _patientRepo.GetById(id);
            if (existing is null) return null;
            existing.FullName = updatedpatient.FullName;
            existing.Email = updatedpatient.Email;
            existing.Phone = updatedpatient.Phone;
            await _patientRepo.Update(existing);
            return existing;
        }
        public async Task<bool> Delete(int id)
        {
            var existing = await _patientRepo.GetById(id);
            if (existing is null) return false;
            await _patientRepo.Delete(id);
            return true;
        }
    }
}
