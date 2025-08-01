using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate
{
    public sealed record AppointmentRescheduledByPatientEvent(int AppointmentId, DateTime AppointmentDate, string Reason, int PatientId) : IDomainEvent;

}
