using AppointmentSchedulingApp.Domain.AggregatesModel.PaymentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;

using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.ReceptionistAggregate;

public partial class Receptionist:Entity
{
    public int ReceptionistId { get; set; }

    public DateOnly StartDate { get; set; }

    public string? Shift { get; set; }

    public  ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public  UserProfile UserProfile { get; set; } = null!;
}
