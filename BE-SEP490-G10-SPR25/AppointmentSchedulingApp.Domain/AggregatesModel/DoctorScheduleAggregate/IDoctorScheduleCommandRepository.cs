using AppointmentSchedulingApp.Domain.Commons;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate
{
    public interface IDoctorScheduleCommandRepository : IGenericCommandRepository<DoctorSchedule>
    {

    }
}
