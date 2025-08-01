using AppointmentSchedulingApp.Application.UseCases.Appointments.Queries.GetAppointmentsByPatientIdAndFilter;
using AppointmentSchedulingApp.Domain.Commons;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.Abstractions.Search.Repositories
{
    public interface IAppointmentQueryRepository : IGenericQueryRepository<AppointmentQueryModel>
    {


    }
}
