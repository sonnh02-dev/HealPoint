using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.SlotAggregate;

public partial class Slot:Entity
{
    public int SlotId { get; set; }

    public TimeOnly SlotStartTime { get; set; }

    public TimeOnly SlotEndTime { get; set; }

    public  ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();
}
