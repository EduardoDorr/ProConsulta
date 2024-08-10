using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using ProConsulta.Components.Pages.Doctors.Models;
using ProConsulta.Models.Doctors;
using ProConsulta.Extensions;
using ProConsulta.Models.Specialities;

namespace ProConsulta.Components.Pages.Doctors;

public class CreatePage : BasePage
{
    [Inject]
    public IDoctorRepository DoctorRepository { get; set; } = null!;
    [Inject]
    public ISpecialityRepository SpecialityRepository { get; set; } = null!;

    public List<Speciality> Specialities { get; set; } = [];
    public DoctorInputModel InputModel { get; set; } = new DoctorInputModel();

    protected override async Task OnInitializedAsync()
    {
        Specialities = await SpecialityRepository.GetAllAsync();
    }

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (editContext.Model is DoctorInputModel)
            {
                var doctor =
                    new Doctor
                    {
                        Name = InputModel.Name,
                        Document = InputModel.Document.RemoveMask(),
                        Crm = InputModel.Crm.RemoveMask(),
                        Email = InputModel.Email,
                        Telephone = InputModel.Telephone.RemoveMask(),
                        CreatedAt = DateTime.Now,
                        SpecialityId = InputModel.SpecialityId
                    };

                await DoctorRepository.AddAsync(doctor);

                Snackbar.Add(
                    "Médico foi cadastrado com sucesso!",
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