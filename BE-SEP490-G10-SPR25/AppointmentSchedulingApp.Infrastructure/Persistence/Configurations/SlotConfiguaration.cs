using AppointmentSchedulingApp.Domain.AggregatesModel.SlotAggregate;
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
    internal class SlotConfiguaration : IEntityTypeConfiguration<Slot>
    {
        public void Configure(EntityTypeBuilder<Slot> builder)
        {
            builder.ToTable("Slots", Schemas.Appointment);
            builder.HasKey(e => e.SlotId).HasName("PK_Slots_SlotId");
            builder.Property(e => e.SlotId).ValueGeneratedNever();
            builder.Property(e => e.SlotEndTime).HasDefaultValueSql("(NULL)");
            builder.Property(e => e.SlotStartTime).HasDefaultValueSql("(NULL)");
        }
    }
}
