using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Specialties.Queries.GetAll
{
    public class GetSpecialtyListQuery : IRequest<Result<IEnumerable<SpecialtyQueryModel>>>
    {
    }
}
