using AppointmentSchedulingApp.Application.UseCases.Services.Queries.GetAll;
using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Services.Queries.GetByDoctorId
{
    public class GetServicesByDoctorIdHandler : IRequestHandler<GetServicesByDoctorIdQuery, Result<IEnumerable<ServiceQueryModel>>>
    {
        public Task<Result<IEnumerable< ServiceQueryModel>>> Handle(GetServicesByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
