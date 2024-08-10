using ProConsulta.Models.Doctors;

namespace ProConsulta.Models.Specialities;

public class Speciality
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public ICollection<Doctor> Doctors { get; set; } = [];
}