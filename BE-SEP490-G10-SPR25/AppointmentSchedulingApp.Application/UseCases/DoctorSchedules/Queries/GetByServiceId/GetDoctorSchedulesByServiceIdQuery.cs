
using AppointmentSchedulingApp.SharedKernel;
using MediatR;

namespace AppointmentSchedulingApp.Application.UseCases.DoctorSchedules.Queries.GetByServiceId
{
    public class GetDoctorSchedulesByServiceIdQuery:IRequest<Result<IEnumerable<DoctorScheduleQueryModel>>>
    {
         public int ServiceId { get; set; }
    }
}
