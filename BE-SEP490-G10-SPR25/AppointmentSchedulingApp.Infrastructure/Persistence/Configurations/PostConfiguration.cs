using AppointmentSchedulingApp.Domain.AggregatesModel.PaymentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
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
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts", Schemas.Content);

            builder.HasKey(p => p.PostId).HasName("PK_Posts_PostId");

            builder.Property(p => p.PostAuthorId).IsRequired();
            builder.Property(p => p.PostCreatedDate).HasColumnType("datetime");
            builder.Property(p => p.PostSourceUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");

            builder.Property(p => p.PostTitle).HasMaxLength(200);

            builder.HasOne(p => p.PostAuthor)
                .WithMany(up => up.Posts)
                .HasForeignKey(p => p.PostAuthorId)
                .HasConstraintName("FK_Posts_UserProfiles_Id")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
