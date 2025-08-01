using AppointmentSchedulingApp.Domain.AggregatesModel.HospitalAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Configurations
{
    public class WardConfiguaration : IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.ToTable("Wards", Schemas.Appointment);
            builder.HasKey(w => w.WardId)
                .HasName("PK_Wards_WardId");
            builder.Property(w => w.Name).HasMaxLength(100);
            builder.HasOne(w => w.District)
                   .WithMany(d => d.Wards)
                   .HasForeignKey(w => w.DistrictId)
                   .HasConstraintName("Wards_Districts_DistrictId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
