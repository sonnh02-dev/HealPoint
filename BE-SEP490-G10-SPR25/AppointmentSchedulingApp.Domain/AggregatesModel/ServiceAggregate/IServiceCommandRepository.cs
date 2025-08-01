using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentSchedulingApp.Domain.Commons;


namespace AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate
{
    public interface IServiceCommandRepository : IGenericCommandRepository<Service>    
    {

        Task<IQueryable<Service>> GetServicesBySpecialty(int specialtyId);
    }
}
