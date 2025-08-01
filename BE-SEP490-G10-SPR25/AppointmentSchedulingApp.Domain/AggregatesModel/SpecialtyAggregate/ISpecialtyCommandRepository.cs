using AppointmentSchedulingApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate
{
    public interface ISpecialtyCommandRepository : IGenericCommandRepository<Specialty>
    {
    }
}
