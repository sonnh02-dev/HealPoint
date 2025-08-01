using AppointmentSchedulingApp.Domain.AggregatesModel.FeedbackAggregate;
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
    internal class FeedbackConfiguaration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks",Schemas.Content);
            builder.HasKey(f => f.AppointmentId)
                .HasName("PK_Feedbacks_AppointmentId");

            builder.Property(d => d.AppointmentId)
                .ValueGeneratedNever();


            builder.Property(f => f.FeedbackDate).HasColumnType("datetime");

            builder.HasOne(f => f.Appointment)
                .WithOne(ap => ap.Feedback)
                .HasForeignKey<Feedback>(d => d.AppointmentId)
                .HasConstraintName("FK_Feedbacks_Appointments_AppointmentId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
