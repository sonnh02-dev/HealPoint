using AppointmentSchedulingApp.Domain.AggregatesModel.RoomAggregate;
using AppointmentSchedulingApp.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Configurations
{
    internal class RoomConfiguaration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms", Schemas.Appointment);

            builder.HasKey(r => r.RoomId)
                   .HasName("PK_Rooms_RoomId");

            builder.Property(r => r.Location).HasMaxLength(255);
            builder.Property(r => r.RoomName).HasMaxLength(100);
            builder.Property(r => r.RoomType).HasMaxLength(50);

            builder.HasOne(r=>r.Hospital)
                .WithMany(r => r.Rooms)
                .HasConstraintName("Rooms_Hospitals_HospitalId")
                .HasForeignKey(r => r.HospitalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
