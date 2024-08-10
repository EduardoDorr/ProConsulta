using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using ProConsulta.Models.Patients;
using ProConsulta.Components.Pages.Patients.Models;
using ProConsulta.Extensions;

namespace ProConsulta.Components.Pages.Patients;

public class CreatePage : BasePage
{
    [Inject]
    public IPatientRepository PatientRepository { get; set; } = null!;

    public PatientInputModel InputModel { get; set; } = new PatientInputModel();
    public DateTime? BirthDate { get; set; } = DateTime.Today;
    public DateTime? MaxDate { get; set; } = DateTime.Today;

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (editContext.Model is PatientInputModel)
            {
                var patient =
                    new Patient
                    {
                        Name = InputModel.Name,
                        Document = InputModel.Document.RemoveMask(),
                        Email = InputModel.Email,
                        Telephone = InputModel.Telephone.RemoveMask(),
                        BirthDate = BirthDate.Value,
                    };

                await PatientRepository.AddAsync(patient);

                Snackbar.Add(
                    "Paciente foi cadastrado com sucesso!",
                    MudBlazor.Severity.Success);

                NavigationManager.NavigateTo("/pacientes");
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(
                ex.Message,
                MudBlazor.Severity.Error);
        }
    }
}