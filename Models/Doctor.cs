namespace hospital.Models;
public class Doctor
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string Speciality { get; set; } = string.Empty;

    public ICollection<Appointment> Appointment { get; set; } = [];

}