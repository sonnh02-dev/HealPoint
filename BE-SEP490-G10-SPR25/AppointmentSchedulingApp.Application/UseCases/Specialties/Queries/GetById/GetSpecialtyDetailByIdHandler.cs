using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Specialties.Queries.GetById
{
    public class GetSpecialtyDetailByIdHandler : IRequestHandler<GetSpecialtyDetailByIdQuery, Result<SpecialtyDetailQueryModel>>
    {
        public Task<Result<SpecialtyDetailQueryModel>> Handle(GetSpecialtyDetailByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
