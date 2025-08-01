using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.ConstrainedExecution;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Configurations
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors", Schemas.Staff);

            builder.HasKey(d => d.DoctorId).HasName("PK_Doctors_DoctorId");
            builder.Property(d => d.DoctorId).ValueGeneratedNever();
            builder.Property(d => d.CurrentWork)
                   .HasMaxLength(500);

            builder.Property(d => d.DoctorDescription)
                   .HasMaxLength(1000);

            builder.Property(d => d.Organization)
                   .HasMaxLength(200);

            builder.Property(d => d.Prize)
                   .HasMaxLength(500);

            builder.Property(d => d.ResearchProject)
                   .HasMaxLength(500);

            builder.Property(d => d.TrainingProcess)
                   .HasMaxLength(1000);

            builder.Property(d => d.WorkExperience)
                   .HasMaxLength(1000);

            builder.Property(d => d.AcademicTitle)
                   .HasMaxLength(100);

            builder.Property(d => d.Degree)
                   .HasMaxLength(100);

            //builder.Property(d => d.IsActive)
            //       .IsRequired()
            //       .HasDefaultValue(true);

            // Quan hệ 1-1 với UserProfile
            builder.HasOne(d => d.UserProfile)
                   .WithOne(up => up.Doctor)
                   .HasForeignKey<Doctor>(d => d.DoctorId)
                   .HasConstraintName("FK_Doctors_UserProfiles_Id")
                   .OnDelete(DeleteBehavior.Cascade);

            //Nếu cấu hình như dưới ko cấu hình sâu contrain,delete behavior,...
            //builder.HasMany(d => d.Services)
            //       .WithMany(ser => ser.Doctors)
            //       .UsingEntity(j => j.ToTable("DoctorServices"));

            //builder.HasMany(d => d.Specialties)
            //       .WithMany(spe => spe.Doctors)
            //       .UsingEntity(j => j.ToTable("DoctorSpecialties"));

            // Quan hệ n-n với Specialties
            builder.HasMany(d => d.Specialties)
                   .WithMany(s => s.Doctors)
                   .UsingEntity<Dictionary<string, object>>(
                   "DoctorSpecialties",
            j => j.HasOne<Specialty>().WithMany()
                  .HasForeignKey("SpecialtyId")
                  .HasConstraintName("FK_DoctorSpecialties_Specialties_SpecialtyId")
                  .OnDelete(DeleteBehavior.Cascade),
            j => j.HasOne<Doctor>().WithMany()
                  .HasForeignKey("DoctorId")
                  .HasConstraintName("FK_DoctorSpecialties_Doctors_DoctorId")
                  .OnDelete(DeleteBehavior.Cascade)
,
            j =>
            {
                j.HasKey("SpecialtyId", "DoctorId");
                j.ToTable("DoctorSpecialties");
            });
            // Quan hệ n-n với Services
            builder.HasMany(d => d.Services)
                  .WithMany(s => s.Doctors)
                  .UsingEntity<Dictionary<string, object>>(
                   "DoctorServices",
            j => j.HasOne<Service>()
                  .WithMany()
                  .HasForeignKey("ServiceId")
                  .HasConstraintName("FK_DoctorServices_Services_ServiceId")
                  .OnDelete(DeleteBehavior.Cascade),
            j => j.HasOne<Doctor>()
                  .WithMany()
                  .HasForeignKey("DoctorId")
                  .HasConstraintName("FK_DoctorServices_Doctors_DoctorId")
                  .OnDelete(DeleteBehavior.Cascade),
            j =>
            {
                j.HasKey("ServiceId", "DoctorId");
                j.ToTable("DoctorServices");
            });


            
        }
    }
}
