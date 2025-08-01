using AppointmentSchedulingApp.Application.UseCases.Doctors.Queries.GetByFilter;
using AppointmentSchedulingApp.Domain.Commons;

namespace AppointmentSchedulingApp.Application.Abstractions.Search.Repositories
{
    public interface IDoctorQueryRepository : IGenericQueryRepository<DoctorQueryModel>
    {
       
    }
}
