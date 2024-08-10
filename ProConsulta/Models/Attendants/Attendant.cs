using ProConsulta.Data;

namespace ProConsulta.Models.Attendants;

public class Attendant : ApplicationUser
{
    public string Name { get; set; } = null!;
}