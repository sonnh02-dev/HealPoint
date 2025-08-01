using AppointmentSchedulingApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.CertificationAggregate
{
    public interface ICertificationCommandRepository:IGenericCommandRepository<Certification>
    {
    }
}
