namespace hospital.Models;
public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

    public string? Notes { get; set; }
    public Doctor Doctor { get; set; } = default!;
    public Patient Patient { get; set; } = default!;
    public Prescription? Prescription { get; set; }

}
public enum AppointmentStatus
{
    Pending,
    Approved,
    Cancelled
}