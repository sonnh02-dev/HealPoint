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
    public class ProvinceConfiguaration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Provinces", Schemas.Appointment);
            builder.HasKey(p => p.ProvinceId)
                   .HasName("PK_Provinces_ProvinceId");

            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

           

        }
    }
}
