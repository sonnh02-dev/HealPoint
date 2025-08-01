using AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate;
using AppointmentSchedulingApp.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Configurations
{
    internal class SpecialtyConfiguaration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.ToTable("Specialties",Schemas.Medical)
                .HasKey(e => e.SpecialtyId)
                .HasName("PK_Specialties_SpecialtyId");

            builder.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false);
            builder.Property(e => e.SpecialtyName)
                .HasMaxLength(100);

            builder.Property(e => e.SpecialtyDescription)
            .HasMaxLength(500);

           
         
        }
    }
}
