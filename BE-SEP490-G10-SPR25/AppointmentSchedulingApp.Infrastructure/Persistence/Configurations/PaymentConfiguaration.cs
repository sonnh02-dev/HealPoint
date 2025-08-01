using AppointmentSchedulingApp.Domain.AggregatesModel.PaymentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Configurations
{
    internal class PaymentConfiguaration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments", Schemas.Billing);

            builder.HasKey(pm => pm.AppointmentId)
                   .HasName("PK_Payments_AppointmentId");

            builder.Property(pm => pm.PaymentDate)
                   .HasColumnType("datetime");

            builder.Property(pm => pm.PaymentMethod)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(pm => pm.PaymentStatus)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(pm => pm.TransactionId)
                   .HasMaxLength(100);

            builder.Property(pm => pm.Amount)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(pm => pm.Payer)
                   .WithMany(pt=>pt.Payments) 
                   .HasForeignKey(pm => pm.PayerId)
                   .HasConstraintName("FK_Payments_Patients_PatientId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pm => pm.Receptionist)
                   .WithMany(r=>r.Payments) 
                   .HasForeignKey(pm => pm.ReceptionistId)
                   .HasConstraintName("FK_Payments_Receptionists_ReceptionistId")
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(pm => pm.Appointment)
                   .WithOne(ap => ap.Payment) 
                   .HasForeignKey<Payment>(pm=>pm.AppointmentId)
                   .HasConstraintName("FK_Payments_Appointments_AppointmentId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
