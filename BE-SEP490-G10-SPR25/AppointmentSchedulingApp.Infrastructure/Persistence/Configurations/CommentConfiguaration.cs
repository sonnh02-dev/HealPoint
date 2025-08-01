using AppointmentSchedulingApp.Domain.AggregatesModel.CommentAggregate;
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
    internal class CommentConfiguaration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments", Schemas.Content);

            builder.HasKey(e => e.CommentId).HasName("PK_Comments_CommentId");

            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
               .HasConstraintName("FK_Comments_Posts_PostId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Patient)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Comments_Patients_PatientId")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
