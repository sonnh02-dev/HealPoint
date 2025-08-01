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
    public sealed record AppointmentCanceledEvent(int AppointmentId,string CancellationReason) : IDomainEvent;
    

}


