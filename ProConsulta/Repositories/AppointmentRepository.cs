using Microsoft.EntityFrameworkCore;

using ProConsulta.Data;
using ProConsulta.Models.Appointments;
using System.Text;

namespace ProConsulta.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _context;

    public AppointmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Appointment Appointment)
    {
        _context.Appointments.Add(Appointment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Appointment Appointment)
    {
        _context.Appointments.Update(Appointment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Appointment Appointment)
    {
        _context.Appointments.Remove(Appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Appointment>> GetAllAsync()
    {
        return await _context
            .Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .OrderBy(a => a.Date)
            .ThenBy(a => a.Time)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(int id)
    {
        return await _context
            .Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<AnualAppointments>?> GetReportAsync()
    {
        var query = new StringBuilder();
        query.AppendLine($"SELECT                                   ")
             .AppendLine($" MONTH(Date) AS Month,                   ")
             .AppendLine($" COUNT(*) AS Quantity                    ")
             .AppendLine($"FROM Appointments                        ")
             .AppendLine($"WHERE YEAR(Date) = {DateTime.Today.Year} ")
             .AppendLine($"GROUP BY MONTH(Date)                     ")
             .AppendLine($"ORDER BY Month                           ");

        var result = _context.Database.SqlQueryRaw<AnualAppointments>(query.ToString());

        return await result.ToListAsync();
    }
}