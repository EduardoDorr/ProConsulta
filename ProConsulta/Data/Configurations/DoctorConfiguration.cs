using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models.Doctors;

namespace ProConsulta.Data.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Document)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(x => x.Crm)
            .IsRequired()
            .HasMaxLength(6);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Telephone)
            .IsRequired()
            .HasMaxLength(13);

        builder.Property(x => x.SpecialityId)
            .IsRequired();

        builder.HasIndex(x => x.Document)
            .IsUnique();

        builder.HasOne(x => x.Speciality)
            .WithMany(x => x.Doctors)
            .HasForeignKey(x => x.SpecialityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Appointments)
            .WithOne(x => x.Doctor)
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
