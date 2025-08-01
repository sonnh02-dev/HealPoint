using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Configurations
{
    public class DoctorScheduleConfiguaration : IEntityTypeConfiguration<DoctorSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
        {
            builder.ToTable("DoctorSchedule", Schemas.Appointment);
            builder.HasKey(ds => new { ds.DoctorScheduleId, ds.Version })
                  .HasName("PK_DoctorSchedules_DoctorScheduleId");

            builder.HasIndex(ds => new { ds.DoctorId, ds.ServiceId, ds.DayOfWeek, ds.SlotId, ds.RoomId })
           .IsUnique();

            builder.Property(ds => ds.DayOfWeek).HasMaxLength(10);

            builder.HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSchedules)
                .HasForeignKey(ds => ds.DoctorId)
                 .HasConstraintName("FK_DoctorSchedules_Doctors_DoctorId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ds => ds.Room)
                .WithMany(r => r.DoctorSchedules)
                .HasForeignKey(ds => ds.RoomId)
               .HasConstraintName("FK_DoctorSchedules_Rooms_RoomId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ds => ds.Service)
                .WithMany(sv => sv.DoctorSchedules)
                .HasForeignKey(ds => ds.ServiceId)
               .HasConstraintName("FK_DoctorSchedules_Services_ServiceId")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ds => ds.Slot)
                .WithMany(sl => sl.DoctorSchedules)
                .HasForeignKey(ds => ds.SlotId)
                .HasConstraintName("FK_DoctorSchedules_Slots_SlotId")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
