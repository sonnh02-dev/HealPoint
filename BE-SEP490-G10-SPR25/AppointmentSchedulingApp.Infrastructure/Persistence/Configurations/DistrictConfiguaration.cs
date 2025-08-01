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
    internal class DistrictConfiguaration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("Districts", Schemas.Appointment);
            builder.HasKey(dstr=> dstr.DistrictId)
                   .HasName("PK_Districts_DistrictId");
            builder.Property(dstr => dstr.Name)
                   .IsRequired().HasMaxLength(100);

            builder.HasOne(dstr => dstr.Province)
                 .WithMany(p => p.Districts)
                 .HasForeignKey(dstr => dstr.ProvinceId)
                 .HasConstraintName("Districts_Provinces_ProvinceId")
                 .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
