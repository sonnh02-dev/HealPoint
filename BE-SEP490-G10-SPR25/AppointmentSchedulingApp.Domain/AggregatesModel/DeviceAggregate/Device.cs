using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.DeviceAggregate;

public partial class Device:Entity
{
    public int DeviceId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; }

    public string Functionality { get; set; }

    public  ICollection<Service> Services { get; set; } = new List<Service>();
}
