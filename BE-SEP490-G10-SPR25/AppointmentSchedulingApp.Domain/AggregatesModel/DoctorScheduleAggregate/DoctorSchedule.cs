using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.RoomAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.SlotAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;

public partial class DoctorSchedule:AuditableEntity
{
    public int DoctorScheduleId { get; set; }

    public int DoctorId { get; set; }

    public int ServiceId { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public int RoomId { get; set; }

    public int SlotId { get; set; }

    public  Doctor Doctor { get; set; } = null!;

    public  ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public  Room Room { get; set; } = null!;

    public  Service Service { get; set; } = null!;

    public  Slot Slot { get; set; } = null!;
}
