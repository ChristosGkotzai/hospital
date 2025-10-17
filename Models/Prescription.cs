namespace hospital.Models;
public class Prescription
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public string Medication { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public string? Notes { get; set; }

    public Appointment Appointment { get; set; } = default!;
}