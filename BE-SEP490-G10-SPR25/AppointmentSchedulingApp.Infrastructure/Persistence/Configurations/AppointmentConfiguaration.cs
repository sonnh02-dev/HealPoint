using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Configurations
{
    internal class AppointmentConfiguaration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments", Schemas.Appointment);

            builder.HasKey(ap => ap.AppointmentId).HasName("PK_Appointments_AppointmentId");

            builder.HasIndex(ap => new { ap.DoctorScheduleId, ap.AppointmentDate }).IsUnique();

            builder.Property(ap => ap.AppointmentDate).HasColumnType("datetime");

            builder.Property(ap => ap.CancellationReason).HasMaxLength(255);

            builder.Property(ap => ap.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            builder.Property(ap => ap.PriorExaminationImg).HasMaxLength(200);

            builder.Property(ap => ap.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Đang chờ");

            builder.Property(ap => ap.ModifiedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            builder.HasOne(ap => ap.Creator)
                .WithMany(up => up.CreatedAppointments)
                .HasForeignKey(ap => ap.CreatorId)
                .HasConstraintName("FK_Appointments_UserProfiles_CreatorId")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(ap => ap.Modifier)
                .WithMany(up => up.ModifiedAppointments)
                .HasForeignKey(ap => ap.ModifierId)
                .HasConstraintName("FK_Appointments_UserProfiles_ModifierId")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(ap => ap.DoctorSchedule)
                .WithMany(ds => ds.Appointments)
                .HasForeignKey(ap => ap.DoctorScheduleId)
                .HasConstraintName("FK_Appointments_DoctorSchedules_DoctorScheduleId")
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(ap => ap.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(ap => ap.PatientId)
                .HasConstraintName("FK_Appointments_Patients_PatientId")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
