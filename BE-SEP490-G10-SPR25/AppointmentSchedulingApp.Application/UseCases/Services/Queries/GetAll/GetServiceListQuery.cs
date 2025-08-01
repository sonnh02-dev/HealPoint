using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Services.Queries.GetAll
{
    public class GetServiceListQuery : IRequest<Result<IEnumerable<ServiceQueryModel>>>
    {
    }
}
