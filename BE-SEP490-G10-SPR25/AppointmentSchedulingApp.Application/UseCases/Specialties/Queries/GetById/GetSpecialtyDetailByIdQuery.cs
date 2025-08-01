using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Specialties.Queries.GetById
{
    public class GetSpecialtyDetailByIdQuery : IRequest<Result<SpecialtyDetailQueryModel>>
    {
    }
}
