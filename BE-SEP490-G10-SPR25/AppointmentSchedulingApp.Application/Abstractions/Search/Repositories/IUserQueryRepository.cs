using AppointmentSchedulingApp.Application.UseCases.Users.Queries.GetBySearchValue;
using AppointmentSchedulingApp.Domain.Commons;


namespace AppointmentSchedulingApp.Application.Abstractions.Search.Repositories
{
    public interface IUserQueryRepository:IGenericQueryRepository<UserQueryModel>
    {
    }
}
