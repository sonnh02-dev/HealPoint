using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Services.Queries.GetById
{
    public class GetServiceDetailByIdHandler : IRequestHandler<GetServiceDetailByIdQuery, Result<ServiceDetailQueryModel>>
    {
        public Task<Result<ServiceDetailQueryModel>> Handle(GetServiceDetailByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
