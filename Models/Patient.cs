namespace hospital.Models;
public class Patient
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime Birth { get; set; }

    public string? Address { get; set; }
    public string? Phone { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = [];

}