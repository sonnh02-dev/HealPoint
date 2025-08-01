using AppointmentSchedulingApp.Domain.AggregatesModel.DeviceAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate;
using AppointmentSchedulingApp.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Configurations
{
    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services", Schemas.Medical);

            builder.HasKey(serv => serv.ServiceId)
                .HasName("PK_Services_ServiceId");

            builder.Property(serv => serv.ServiceName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(serv => serv.Overview)
                .HasMaxLength(500);

            builder.Property(serv => serv.Process)
                .HasMaxLength(1000);

            builder.Property(serv => serv.TreatmentTechniques)
                .HasMaxLength(1000);

            builder.Property(serv => serv.Price)
                .HasColumnType("decimal(18, 2)");

            builder.Property(serv => serv.EstimatedTime);

            //builder.Property(serv => serv.IsActive)
            //    .IsRequired()
            //    .HasDefaultValue(true);

            builder.Property(serv => serv.Image)
                .HasMaxLength(200)
                .IsUnicode(false);

            // Quan hệ nhiều - một với Specialty
            builder.HasOne(serv => serv.Specialty)
                .WithMany(sp => sp.Services)
                .HasForeignKey(serv => serv.SpecialtyId)
                .HasConstraintName("FK_Services_Specialties_SpecialtyId")
                .OnDelete(DeleteBehavior.ClientSetNull);



            // Quan hệ nhiều - nhiều với Devices qua bảng trung gian DeviceServices
            builder.HasMany(serv => serv.Devices)
                .WithMany(d => d.Services)
                .UsingEntity<Dictionary<string, object>>(
                    "DeviceServices",
                    j => j.HasOne<Device>().WithMany()
                          .HasForeignKey("DeviceId")
                          .HasConstraintName("FK_DeviceServices_Devices_DeviceId")
                          .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Service>().WithMany()
                          .HasForeignKey("ServiceId")
                          .HasConstraintName("FK_DeviceServices_Services_ServiceId")
                          .OnDelete(DeleteBehavior.Cascade),

                    j =>
                    {
                        j.HasKey("ServiceId", "DeviceId");
                        j.ToTable("DeviceServices");
                    });


        }
    }
}
