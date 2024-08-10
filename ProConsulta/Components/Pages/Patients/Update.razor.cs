using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using ProConsulta.Components.Pages.Patients.Models;
using ProConsulta.Models.Patients;
using ProConsulta.Extensions;

namespace ProConsulta.Components.Pages.Patients;

public class UpdatePage : BasePage
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    public IPatientRepository PatientRepository { get; set; } = null!;

    public PatientInputModel InputModel { get; set; } = new PatientInputModel();
    public DateTime? BirthDate { get; set; } = DateTime.Today;
    public DateTime? MaxDate { get; set; } = DateTime.Today;

    private Patient? _currentPatient;

    protected override async Task OnInitializedAsync()
    {
        _currentPatient = await PatientRepository.GetByIdAsync(Id);

        if (_currentPatient is null)
            return;

        InputModel = new PatientInputModel
        {
            Name = _currentPatient.Name,
            Document = _currentPatient.Document,
            BirthDate = _currentPatient.BirthDate,
            Email = _currentPatient.Email,
            Telephone = _currentPatient.Telephone
        };

        BirthDate = _currentPatient.BirthDate;
    }

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (editContext.Model is PatientInputModel)
            {
                _currentPatient.Name = InputModel.Name;
                _currentPatient.Document = InputModel.Document.RemoveMask();
                _currentPatient.Email = InputModel.Email;
                _currentPatient.Telephone = InputModel.Telephone.RemoveMask();
                _currentPatient.BirthDate = BirthDate.Value;

                await PatientRepository.UpdateAsync(_currentPatient);

                Snackbar.Add(
                    "Paciente foi atualizado com sucesso!",
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