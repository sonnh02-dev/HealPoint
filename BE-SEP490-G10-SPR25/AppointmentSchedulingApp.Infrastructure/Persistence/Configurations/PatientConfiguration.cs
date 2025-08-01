using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Configurations
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients", Schemas.Patient);

            // Khóa chính
            builder.HasKey(p => p.PatientId)
                   .HasName("PK_Patients_PatientId");

            builder.Property(d => d.PatientId)
                   .ValueGeneratedNever();


            builder.Property(p => p.Occupation)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.MainCondition)
                   .HasMaxLength(500);

            builder.Property(p => p.Rank)
                   .HasMaxLength(50);

            builder.Property(p => p.Relationship)
                   .HasMaxLength(50);

            // Quan hệ 1-1 với UserProfile
            builder.HasOne(p => p.UserProfile)
                   .WithOne(up => up.Patient)
                   .HasForeignKey<Patient>(p => p.PatientId)
                   .HasConstraintName("FK_Patients_UserProfiles_Id")
                   .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ 1-1  với Guardian 
            builder.HasOne(p => p.Guardian)
                   .WithMany(g=>g.Dependents)
                   .HasForeignKey(p => p.GuardianId)
                   .HasConstraintName("FK_Patients_Patients_PatientId")
                   .OnDelete(DeleteBehavior.Cascade);

        

        }
    }
}
