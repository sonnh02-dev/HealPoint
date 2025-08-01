using AppointmentSchedulingApp.Domain.Commons;

using System.Linq.Expressions;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.DeviceAggregate
{
    public interface IDeviceRepository:IGenericCommandRepository<Device>
    {
        
    }
} 