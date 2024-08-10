using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using ProConsulta.Extensions;
using ProConsulta.Models.Doctors;
using ProConsulta.Components.Pages.Doctors.Models;
using ProConsulta.Models.Specialities;

namespace ProConsulta.Components.Pages.Doctors;

public class UpdatePage : BasePage
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    public IDoctorRepository DoctorRepository { get; set; } = null!;
    [Inject]
    public ISpecialityRepository SpecialityRepository { get; set; } = null!;

    public DoctorInputModel InputModel { get; set; } = new DoctorInputModel();
    public List<Speciality> Specialities { get; set; } = [];

    private Doctor? _currentDoctor;

    protected override async Task OnInitializedAsync()
    {
        _currentDoctor = await DoctorRepository.GetByIdAsync(Id);
        Specialities = await SpecialityRepository.GetAllAsync();

        if (_currentDoctor is null)
            return;

        InputModel = new DoctorInputModel
        {
            Name = _currentDoctor.Name,
            Document = _currentDoctor.Document,
            Crm = _currentDoctor.Crm,
            Email = _currentDoctor.Email,
            Telephone = _currentDoctor.Telephone,
            SpecialityId = _currentDoctor.SpecialityId
        };
    }

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (editContext.Model is DoctorInputModel)
            {
                _currentDoctor.Name = InputModel.Name;
                _currentDoctor.Document = InputModel.Document.RemoveMask();
                _currentDoctor.Crm = InputModel.Crm;
                _currentDoctor.Email = InputModel.Email;
                _currentDoctor.Telephone = InputModel.Telephone.RemoveMask();
                _currentDoctor.SpecialityId = InputModel.SpecialityId;

                await DoctorRepository.UpdateAsync(_currentDoctor);

                Snackbar.Add(
                    "Médico foi atualizado com sucesso!",
                    MudBlazor.Severity.Success);

                NavigationManager.NavigateTo("/medicos");
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