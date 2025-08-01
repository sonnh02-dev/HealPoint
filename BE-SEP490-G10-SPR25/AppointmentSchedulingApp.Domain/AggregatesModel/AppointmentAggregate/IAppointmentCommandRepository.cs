using AppointmentSchedulingApp.Domain.Commons;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate
{
    public interface IAppointmentCommandRepository : IGenericCommandRepository<Appointment>
    {


    }
}
