using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Configurations
{
    internal class PostSectionConfiguaration : IEntityTypeConfiguration<PostSection>
    {
        public void Configure(EntityTypeBuilder<PostSection> builder)
        {
            builder.ToTable("PostSections", Schemas.Content);
            builder.HasKey(e => e.SectionId)
                   .HasName("PK_PostSections_SectionId");

            builder.Property(e => e.PostImageUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
            builder.Property(e => e.SectionTitle).HasMaxLength(200);

            builder.HasOne(d => d.Post)
                .WithMany(p => p.PostSections)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_PostSections_Posts_PostId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
