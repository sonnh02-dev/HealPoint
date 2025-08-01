using System;
using System.Collections.Generic;
using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.CertificationAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.CommentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DeviceAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.FeedbackAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.HospitalAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.MedicalRecordAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PaymentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ReceptionistAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.RoomAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.SlotAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;
using AppointmentSchedulingApp.Infrastructure.Outbox;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchedulingApp.Infrastructure.Data.Contexts;


public partial class ApplicationCommandDbContext : DbContext
{
    

    public ApplicationCommandDbContext(DbContextOptions<ApplicationCommandDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostSection> PostSections { get; set; }

    public virtual DbSet<Receptionist> Receptionists { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<IdentityUser<int>> UserAccounts { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<OutboxMessage> OutboxMessages { get;set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AppointmentSchedulingDB; Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationCommandDbContext).Assembly, WriteConfigurationsFilter);
    }

    private static bool WriteConfigurationsFilter(Type type) =>
        type.FullName?.Contains("Configurations.Command") ?? false;
}
