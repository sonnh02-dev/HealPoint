using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ReceptionistAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;
using AppointmentSchedulingApp.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

public sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("UserProfiles",Schemas.Patient);

        builder.HasKey(up => up.Id)
               .HasName("PK_UserProfiles_Id");

        builder.Property(up => up.CitizenId)
               .IsRequired();

        builder.Property(up => up.FullName)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(up => up.Gender)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(up => up.Address)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(up => up.Nationality)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(up => up.Ethnicity)
               .HasMaxLength(100);

        builder.Property(up => up.AvatarUrl) 
               .HasMaxLength(300)
               .HasDefaultValue("user.jpg");

        builder.Property(up => up.IsVerify)
               .HasDefaultValue(false);

        builder.Property(up => up.IsActive)
               .HasDefaultValue(true);
      

        builder.HasOne<IdentityUser<int>>() // dùng generic type vì không có navigation ngược
            .WithOne()
            .HasForeignKey<UserProfile>(up => up.Id)
            .HasConstraintName("FK_UserProfiles_UserAccounts_Id")  
            .OnDelete(DeleteBehavior.Cascade);


    }
}
