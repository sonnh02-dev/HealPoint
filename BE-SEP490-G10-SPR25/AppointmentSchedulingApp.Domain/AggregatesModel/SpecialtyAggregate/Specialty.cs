using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate;

public partial class Specialty:Entity
{
    public int SpecialtyId { get; set; }

    public string SpecialtyName { get; set; } = null!;

    public string SpecialtyDescription { get; set; }=null!;

    public string Image { get; set; } = null!;

    public  ICollection<Service> Services { get; set; } = new List<Service>();

    public  ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
