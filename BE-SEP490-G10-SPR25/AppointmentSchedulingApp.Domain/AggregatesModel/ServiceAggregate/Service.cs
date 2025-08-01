using AppointmentSchedulingApp.Domain.AggregatesModel.DeviceAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;

public partial class Service:AuditableEntity
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string Overview { get; set; }

    public string Process { get; set; }

    public string TreatmentTechniques { get; set; }

    public decimal Price { get; set; }

    public TimeOnly EstimatedTime { get; set; }


    public int SpecialtyId { get; set; }

    public string Image { get; set; }


    public  ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();

    public  Specialty Specialty { get; set; } = null!;

    public  ICollection<Device> Devices { get; set; } = new List<Device>();

    public  ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
