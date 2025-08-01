using AppointmentSchedulingApp.Application.UseCases.Specialties.Queries.GetAll;
using AppointmentSchedulingApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.Abstractions.Search.Repositories
{
    public interface ISpecialtyQueryRepository : IGenericQueryRepository<SpecialtyQueryModel>
    {
    }
}
