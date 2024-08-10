using Microsoft.EntityFrameworkCore;

using ProConsulta.Data;
using ProConsulta.Models.Specialities;

namespace ProConsulta.Repositories;

public class SpecialityRepository : ISpecialityRepository
{
    private readonly ApplicationDbContext _context;

    public SpecialityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Speciality speciality)
    {
        _context.Specialities.Add(speciality);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Speciality speciality)
    {
        _context.Specialities.Update(speciality);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Speciality speciality)
    {
        _context.Specialities.Remove(speciality);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Speciality>> GetAllAsync()
    {
        return await _context.Specialities.AsNoTracking().ToListAsync();
    }

    public async Task<Speciality?> GetByIdAsync(int id)
    {
        return await _context.Specialities.SingleOrDefaultAsync(p => p.Id == id);
    }
}