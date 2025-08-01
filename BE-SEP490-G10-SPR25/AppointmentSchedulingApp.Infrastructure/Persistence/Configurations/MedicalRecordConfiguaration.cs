using AppointmentSchedulingApp.Domain.AggregatesModel.MedicalRecordAggregate;
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
    internal class MedicalRecordConfiguaration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.ToTable("MedicalRecords", Schemas.Medical);
            builder.HasKey(e => e.AppointmentId)
                   .HasName("PK_MedicalRecords_AppointmentId");

            builder.Property(e => e.AppointmentId)
                   .ValueGeneratedNever();

            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            builder.Property(e => e.FollowUpDate).HasColumnType("datetime");

            builder.HasOne(d => d.Appointment)
                .WithOne(p => p.MedicalRecord)
                .HasForeignKey<MedicalRecord>(d => d.Id)
                .HasConstraintName("FK_MedicalRecords_Appointments_AppointmentId");
        }
    }
}
