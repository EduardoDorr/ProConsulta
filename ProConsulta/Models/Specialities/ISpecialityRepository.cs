namespace ProConsulta.Models.Specialities;

public interface ISpecialityRepository
{
    Task AddAsync(Speciality speciality);
    Task UpdateAsync(Speciality speciality);
    Task DeleteAsync(Speciality speciality);
    Task<List<Speciality>> GetAllAsync();
    Task<Speciality?> GetByIdAsync(int id);
}