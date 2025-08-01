using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.HospitalAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.RoomAggregate;

public partial class Room:Entity
{
    public int RoomId { get; set; }
    public int HospitalId { get; set; }  

    public string RoomName { get; set; } = null!;

    public string RoomType { get; set; } = null!;

    public string Location { get; set; } = null!;

    public  ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();
    public Hospital Hospital { get; set; }

}
