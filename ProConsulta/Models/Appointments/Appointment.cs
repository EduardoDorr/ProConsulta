using ProConsulta.Models.Doctors;
using ProConsulta.Models.Patients;

namespace ProConsulta.Models.Appointments;

public class Appointment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public string? Observation { get; set; }
    public TimeOnly Time { get; set; }
    public DateOnly Date { get; set; }
    public DateTime CreatedDate { get; set; }

    public Patient Patient { get; set; } = null!;
    public Doctor Doctor { get; set; } = null!;
}