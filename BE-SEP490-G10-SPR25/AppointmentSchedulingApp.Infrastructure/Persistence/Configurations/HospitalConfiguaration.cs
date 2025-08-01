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
    public class HospitalConfiguaration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.ToTable("Hospitals", Schemas.Appointment);
            builder.HasKey(h => h.HospitalId)
                   .HasName("PK_Hospitals_HospitalId");

            builder.Property(h => h.Name)
                    .IsRequired()
                    .HasMaxLength(100);
         

            builder.HasOne(h => h.Province)
                  .WithMany()
                  .HasForeignKey(h => h.ProvinceId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.District)
                   .WithMany()
                   .HasForeignKey(h => h.DistrictId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(h => h.Ward)
                   .WithMany()
                   .HasForeignKey(h => h.WardId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

