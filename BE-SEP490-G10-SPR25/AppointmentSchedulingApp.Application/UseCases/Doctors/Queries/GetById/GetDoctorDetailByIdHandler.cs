using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Doctors.Queries.GetById
{
    internal class GetDoctorDetailByIdHandler : IRequestHandler<GetDoctorDetailByIdQuery, Result<DoctorDetailQueryModel>>
    {
        public Task<Result<DoctorDetailQueryModel>> Handle(GetDoctorDetailByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
