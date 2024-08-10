using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Appointments.Models;

public class AppointmentInputModel
{
    [StringLength(250, ErrorMessage = "Observação deve ter no máximo {1} caracteres")]
    public string? Observation { get; set; }

    [Required(ErrorMessage = "Id do Paciente deve ser fornecido")]
    [RegularExpression("^0*[1-9]\\d*$", ErrorMessage = "Valor selecionado é inválido")]
    public int PatientId { get; set; }

    [Required(ErrorMessage = "Id do Médico deve ser fornecido")]
    [RegularExpression("^0*[1-9]\\d*$*", ErrorMessage = "Valor selecionado é inválido")]
    public int DoctorId { get; set; }

    [Required(ErrorMessage = "Hora da Consulta deve ser fornecido")]
    public TimeOnly Time { get; set; }

    [Required(ErrorMessage = "Data da Consulta deve ser fornecido")]
    public DateOnly Date { get; set; }
}