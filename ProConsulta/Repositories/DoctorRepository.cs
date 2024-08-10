using Microsoft.EntityFrameworkCore;

using ProConsulta.Data;
using ProConsulta.Models.Doctors;

namespace ProConsulta.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _context;

    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Doctor>> GetAllAsync()
    {
        return await _context.Doctors.AsNoTracking().ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(int id)
    {
        return await _context
            .Doctors
            .Include(d => d.Appointments)
            .SingleOrDefaultAsync(p => p.Id == id);
    }
}