using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate
{
    public sealed record AppointmentCreatedEvent(int PatientId,int DoctorScheduleId, string? Reason, DateTime AppointmentDate, int CreatorId) : IDomainEvent;
    

}

