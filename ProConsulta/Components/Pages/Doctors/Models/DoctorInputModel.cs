using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Doctors.Models;

public class DoctorInputModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome deve ser fornecido")]
    [StringLength(50, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Documento deve ser fornecido")]
    [StringLength(14, MinimumLength = 11, ErrorMessage = "Documento deve ter {1} caracteres")]
    public string Document { get; set; }

    [Required(ErrorMessage = "CRM deve ser fornecido")]
    public string Crm { get; set; } = null!;

    [Required(ErrorMessage = "E-mail deve ser fornecido")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Telefone deve ser fornecido")]
    public string Telephone { get; set; }

    [Required(ErrorMessage = "Data de nascimento deve ser fornecida")]
    public DateTime CreatedAt { get; set; }

    [Required(ErrorMessage = "Especialidade deve ser fornecida")]
    [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor selecionado é inválido")]
    public int SpecialityId { get; set; }
}