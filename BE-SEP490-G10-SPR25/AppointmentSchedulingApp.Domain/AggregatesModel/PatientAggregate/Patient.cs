using AppointmentSchedulingApp.Domain.AggregatesModel.CommentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PaymentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;

using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;

public partial class Patient : Entity
{
    public int PatientId { get; set; }
    public string Occupation { get; set; }
    public string? MainCondition { get; set; }

    public string? Rank { get; set; }

    public int? GuardianId { get; set; }

    public string? Relationship { get; set; }

    public  Patient? Guardian { get; set; }

    public  UserProfile UserProfile { get; set; } = null!;
    public ICollection<Patient> Dependents { get; private set; } = new List<Patient>();


    public ICollection<Comment> Comments { get; private set; } = new List<Comment>();

    public ICollection<Payment> Payments { get; private set; } = new List<Payment>();

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();
}
