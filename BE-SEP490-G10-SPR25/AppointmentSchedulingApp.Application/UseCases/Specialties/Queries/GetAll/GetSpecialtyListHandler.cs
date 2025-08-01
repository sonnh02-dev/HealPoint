using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Specialties.Queries.GetAll
{
    public class GetSpecialtyListHandler : IRequestHandler<GetSpecialtyListQuery, Result<IEnumerable<SpecialtyQueryModel>>>
    {
        public Task<Result<IEnumerable<SpecialtyQueryModel>>> Handle(GetSpecialtyListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
