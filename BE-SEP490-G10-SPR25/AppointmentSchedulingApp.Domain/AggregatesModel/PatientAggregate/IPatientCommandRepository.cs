using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentSchedulingApp.Domain.Commons;


namespace AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate
{
    public interface IPatientCommandRepository : IGenericCommandRepository<Patient>
    {
    }
}
