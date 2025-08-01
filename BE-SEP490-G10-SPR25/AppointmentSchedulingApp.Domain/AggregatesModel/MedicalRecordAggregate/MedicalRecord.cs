using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.MedicalRecordAggregate;

public partial class MedicalRecord:Entity
{
    public int AppointmentId { get; set; }

    public string? Symptoms { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string TreatmentPlan { get; set; } = null!;

    public DateTime? FollowUpDate { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public  Appointment Appointment { get; set; } = null!;
}
