using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.CertificationAggregate;

public partial class Certification:Entity
{
    public int CertificationId { get; set; }

    public int DoctorId { get; set; }

    public string? CertificationUrl { get; set; }

    public  Doctor Doctor { get; set; } = null!;
}
