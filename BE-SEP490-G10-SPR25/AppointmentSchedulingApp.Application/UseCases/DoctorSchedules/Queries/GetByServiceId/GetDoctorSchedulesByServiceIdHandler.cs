using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.DoctorSchedules.Queries.GetByServiceId
{
    public class GetDoctorSchedulesByServiceIdHandler : IRequestHandler<GetDoctorSchedulesByServiceIdQuery, Result<IEnumerable<DoctorScheduleQueryModel>>>
    {
        public Task<Result<IEnumerable<DoctorScheduleQueryModel>>> Handle(GetDoctorSchedulesByServiceIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
