using ProConsulta.Models.Appointments;
using ProConsulta.Models.Specialities;

namespace ProConsulta.Models.Doctors;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Document { get; set; } = null!;
    public string Crm { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public int SpecialityId { get; set; }

    public Speciality Speciality { get; set; } = null!;
    public ICollection<Appointment> Appointments { get; set; } = [];
}