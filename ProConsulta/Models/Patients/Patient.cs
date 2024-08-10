using ProConsulta.Models.Appointments;

namespace ProConsulta.Models.Patients;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Document { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public DateTime BirthDate { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = [];
}