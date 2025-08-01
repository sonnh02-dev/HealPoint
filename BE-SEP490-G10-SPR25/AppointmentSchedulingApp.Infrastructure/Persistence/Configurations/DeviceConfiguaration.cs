using AppointmentSchedulingApp.Domain.AggregatesModel.DeviceAggregate;
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
    internal class DeviceConfiguaration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Devices",Schemas.Content);
            builder.HasKey(e => e.DeviceId)
                   .HasName("PK_Devices_DeviceId");

            builder.Property(e => e.Name).HasMaxLength(255);
        }
    }
}
