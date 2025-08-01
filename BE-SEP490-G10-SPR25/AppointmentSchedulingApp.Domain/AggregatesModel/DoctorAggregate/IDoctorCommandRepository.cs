using AppointmentSchedulingApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate
{
    public interface IDoctorCommandRepository : IGenericCommandRepository<Doctor>
    {
       
    }
}
