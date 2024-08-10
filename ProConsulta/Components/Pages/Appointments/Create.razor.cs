using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using ProConsulta.Models.Doctors;
using ProConsulta.Models.Patients;
using ProConsulta.Models.Appointments;
using ProConsulta.Components.Pages.Appointments.Models;

namespace ProConsulta.Components.Pages.Appointments;

public class CreatePage : BasePage
{
    [Inject]
    private IAppointmentRepository AppointmentRepository { get; set; } = null!;
    [Inject]
    private IDoctorRepository DoctorRepository { get; set; } = null!;
    [Inject]
    private IPatientRepository PatientRepository { get; set; } = null!;

    public AppointmentInputModel InputModel { get; set; } = new AppointmentInputModel();
    public List<Doctor> Doctors { get; set; } = [];
    public List<Patient> Patients { get; set; } = [];
    public TimeSpan? Time { get; set; } = new TimeSpan(9, 0, 0);
    public DateTime? Date { get; set; } = DateTime.Today;
    public DateTime? MinDate { get; set; } = DateTime.Today;

    protected override async Task OnInitializedAsync()
    {
        Doctors = await DoctorRepository.GetAllAsync();
        Patients = await PatientRepository.GetAllAsync();
    }

    public async Task OnValidSubmitAsync(EditContext editContext)
    {
        try
        {
            if (editContext.Model is AppointmentInputModel model)
            {
                var appointment =
                    new Appointment()
                    {
                        Observation = model.Observation,
                        DoctorId = model.DoctorId,
                        PatientId = model.PatientId,
                        Time = TimeOnly.FromTimeSpan(Time!.Value),
                        Date = DateOnly.FromDateTime(Date!.Value)
                    };

                await AppointmentRepository.AddAsync(appointment);

                Snackbar.Add(
                    "Agendamento realizado com sucesso",
                    MudBlazor.Severity.Success);

                NavigationManager.NavigateTo("/agendamentos");
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