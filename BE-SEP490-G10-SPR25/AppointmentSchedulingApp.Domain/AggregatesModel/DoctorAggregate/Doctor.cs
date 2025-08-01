using AppointmentSchedulingApp.Domain.AggregatesModel.CertificationAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;

using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;

public partial class Doctor:AuditableEntity
{
    public int DoctorId { get; set; }

    public string? CurrentWork { get; set; }

    public string? DoctorDescription { get; set; }

    public string? Organization { get; set; }

    public string? Prize { get; set; }

    public string? ResearchProject { get; set; }

    public string? TrainingProcess { get; set; }

    public string? WorkExperience { get; set; }

    public string? AcademicTitle { get; set; }

    public string? Degree { get; set; }

    //public double Rating { get; set; }

    //public int RatingCount { get; set; }

    public  ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    public  UserProfile UserProfile { get; set; } = null!;

    public  ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();


    public  ICollection<Service> Services { get; set; } = new List<Service>();

    public  ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
}
