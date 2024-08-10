using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models.Appointments;

namespace ProConsulta.Data.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.PatientId)
            .IsRequired();

        builder.Property(x => x.DoctorId)
            .IsRequired();

        builder.Property(x => x.Observation)
            .HasMaxLength(500);

        builder.Property(x => x.Time)
            .IsRequired()
            .HasColumnType("time");

        builder.Property(x => x.Date)
            .IsRequired()
            .HasColumnType("date");
    }
}
