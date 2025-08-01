using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentSchedulingApp.Application.UseCases.Patients.Queries;
using AppointmentSchedulingApp.Domain.Commons;


namespace AppointmentSchedulingApp.Application.Abstractions.Search.Repositories
{
    public interface IPatientQueryRepository : IGenericQueryRepository<PatientQueryModel>
    {
    }
}
