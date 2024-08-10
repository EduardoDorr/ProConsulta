using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using ProConsulta.Models.Doctors;

namespace ProConsulta.Components.Pages.Doctors;

public class IndexPage : BasePage
{
    [Inject]
    public IDoctorRepository DoctorRepository { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }

    public List<Doctor> Doctors { get; set; } = [];

    public bool HideButtons { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        var auth = await AuthenticationState;

        HideButtons = !auth.User.IsInRole("Atendente");

        Doctors = await DoctorRepository.GetAllAsync();
    }

    public void GoToUpdate(int id)
    {
        NavigationManager.NavigateTo($"/medicos/atualizar/{id}");
    }

    public async Task Delete(Doctor doctor)
    {
        try
        {
            var result = await DialogService.ShowMessageBox(
                "Atenção",
                $"Deseja excluir o paciente {doctor.Name}",
                yesText: "SIM",
                noText: "NÃO");

            if (result is true)
            {
                await DoctorRepository.DeleteAsync(doctor);

                Snackbar.Add(
                    $"Médico {doctor.Name} foi excluído com sucesso!",
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