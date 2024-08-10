namespace ProConsulta.Models.Appointments;

public interface IAppointmentRepository
{
    Task AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(Appointment appointment);
    Task<List<Appointment>> GetAllAsync();
    Task<Appointment?> GetByIdAsync(int id);
    Task<List<AnualAppointments>?> GetReportAsync();
}