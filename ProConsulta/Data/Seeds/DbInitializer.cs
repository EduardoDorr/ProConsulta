using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Models.Attendants;
using ProConsulta.Models.Specialities;

namespace ProConsulta.Data.Seeds;

public class DbInitializer
{
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    internal void Seed()
    {
        _modelBuilder
            .Entity<IdentityRole>()
            .HasData
            (
                new IdentityRole
                {
                    Id = "0D152B90-87AF-44A0-B89C-BBA4260C2483",
                    Name = "Atendente",
                    NormalizedName = "ATENDENTE",
                },
                new IdentityRole
                {
                    Id = "074EB170-6DEE-4B4F-8D6C-2BDCFA074556",
                    Name = "Medico",
                    NormalizedName = "MEDICO",
                }
            );

        var hasher = new PasswordHasher<IdentityUser>();

        _modelBuilder
            .Entity<Attendant>()
            .HasData
            (
                new Attendant
                {
                    Id = "B990111E-34CE-4EC2-8618-A768C44CD278",
                    Name = "ProConsulta",
                    Email = "proconsulta@mail.com.br",
                    EmailConfirmed = true,
                    UserName = "proconsulta@mail.com.br",
                    NormalizedEmail = "PROCONSULTA@MAIL.COM.BR",
                    NormalizedUserName = "PROCONSULTA@MAIL.COM.BR",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                }
            );

        _modelBuilder
            .Entity<IdentityUserRole<string>>()
            .HasData
            (
                new IdentityUserRole<string>
                {
                    UserId = "B990111E-34CE-4EC2-8618-A768C44CD278",
                    RoleId = "0D152B90-87AF-44A0-B89C-BBA4260C2483"
                }
            );

        _modelBuilder
            .Entity<Speciality>()
            .HasData
            (
                new Speciality { Id = 1, Name = "Cardiologia", Description = "Especializa-se em questões relacionadas ao coração" },
                new Speciality { Id = 2, Name = "Dermatologia", Description = "Foca em doenças e condições da pele" },
                new Speciality { Id = 3, Name = "Ortopedia", Description = "Trata de ossos, articulações e lesões relacionadas" },
                new Speciality { Id = 4, Name = "Neurologia", Description = "Especializa-se em distúrbios do sistema nervoso" },
                new Speciality { Id = 5, Name = "Pediatria", Description = "Oferece cuidados médicos para crianças" },
                new Speciality { Id = 6, Name = "Oftalmologia", Description = "Foca em cuidados com os olhos e visão" },
                new Speciality { Id = 7, Name = "Oncologia", Description = "Trata do diagnóstico e tratamento do câncer" },
                new Speciality { Id = 8, Name = "Psiquiatria", Description = "Foca em transtornos de saúde mental" },
                new Speciality { Id = 9, Name = "Gastroenterologia", Description = "Trata de distúrbios do sistema digestivo" },
                new Speciality { Id = 10, Name = "Urologia", Description = "Foca em doenças do trato urinário" }
            );
    }
}