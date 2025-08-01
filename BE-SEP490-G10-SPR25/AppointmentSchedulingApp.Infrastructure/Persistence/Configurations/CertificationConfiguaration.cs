using AppointmentSchedulingApp.Domain.AggregatesModel.CertificationAggregate;
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
    internal class CertificationConfiguaration : IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            builder.ToTable("Certifications", Schemas.Content);

            builder.HasKey(e => e.CertificationId).HasName("PK_Certifications_CertificationId");

            builder.Property(e => e.CertificationUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
            .HasDefaultValueSql("(NULL)");

            builder.HasOne(d => d.Doctor)
                .WithMany(p => p.Certifications)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Certifications_Doctors_DoctorId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
