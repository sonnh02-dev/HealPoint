using AppointmentSchedulingApp.Domain.AggregatesModel.ReceptionistAggregate;
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
    internal class ReceptionistConfiguration : IEntityTypeConfiguration<Receptionist>
    {
        public void Configure(EntityTypeBuilder<Receptionist> builder)
        {
            builder.ToTable("Receptionists", Schemas.Staff);

            builder.HasKey(rec => rec.ReceptionistId)
                  .HasName("PK_Receptionists_ReceptionistId");

            builder.Property(d => d.ReceptionistId)
                .ValueGeneratedNever();

            builder.Property(rec => rec.Id).ValueGeneratedNever();
            builder.Property(rec => rec.Shift)
                .HasMaxLength(20)
            .HasDefaultValue("Ca sáng");
       
            builder.HasOne(rec => rec.UserProfile)
                .WithOne(up => up.Receptionist)
                .HasForeignKey<Receptionist>(rec => rec.ReceptionistId)
                .HasConstraintName("FK_Receptionists_UserProfiles_Id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
