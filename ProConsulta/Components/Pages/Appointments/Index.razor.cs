using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

using ProConsulta.Models.Appointments;

namespace ProConsulta.Components.Pages.Appointments;

public class IndexPage : BasePage
{
    [Inject]
    public IAppointmentRepository AppointmentRepository { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }

    public List<Appointment> Appointments { get; set; } = [];

    public bool HideButtons { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        var auth = await AuthenticationState;

        HideButtons = !auth.User.IsInRole("Atendente");

        Appointments = await AppointmentRepository.GetAllAsync();
    }

    public void GoToUpdate(int id)
    {
        NavigationManager.NavigateTo($"/agendamentos/atualizar/{id}");
    }

    public async Task Delete(Appointment appointment)
    {
        try
        {
            var result = await DialogService.ShowMessageBox(
                "Atenção",
                $"Deseja excluir este agendamento?",
                yesText: "SIM",
                noText: "NÃO");

            if (result is true)
            {
                await AppointmentRepository.DeleteAsync(appointment);

                Snackbar.Add(
                    $"Agendamento foi excluído com sucesso!",
                    Severity.Success);

                await OnInitializedAsync();
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(
                ex.Message,
                Severity.Error);
        }
    }
}