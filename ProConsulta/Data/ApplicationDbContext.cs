using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using ProConsulta.Data.Seeds;
using ProConsulta.Models.Patients;
using ProConsulta.Models.Doctors;
using ProConsulta.Models.Appointments;
using ProConsulta.Models.Specialities;

namespace ProConsulta.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Speciality> Specialities { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        new DbInitializer(builder).Seed();

        base.OnModelCreating(builder);
    }
}