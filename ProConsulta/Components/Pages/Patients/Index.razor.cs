using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ProConsulta.Models.Patients;

namespace ProConsulta.Components.Pages.Patients;

public class IndexPage : BasePage
{
    [Inject]
    public IPatientRepository PatientRepository { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }

    public List<Patient> Patients { get; set; } = [];

    public bool HideButtons { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        Patients = await PatientRepository.GetAllAsync();
    }

    public async Task GoToUpdateAsync(int id)
    {
        var auth = await AuthenticationState;

        HideButtons = !auth.User.IsInRole("Atendente");

        NavigationManager.NavigateTo($"/pacientes/atualizar/{id}");
    }

    public async Task Delete(Patient patient)
    {
        try
        {
            var result = await DialogService.ShowMessageBox(
                "Atenção",
                $"Deseja excluir o paciente {patient.Name}",
                yesText: "SIM",
                noText: "NÃO");

            if (result is true)
            {
                await PatientRepository.DeleteAsync(patient);

                Snackbar.Add(
                    $"Paciente {patient.Name} foi excluído com sucesso!",
                    MudBlazor.Severity.Success);

                await OnInitializedAsync();
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