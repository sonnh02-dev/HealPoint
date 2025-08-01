
using AppointmentSchedulingApp.SharedKernel;
using MassTransit;
using MediatR;

namespace AppointmentSchedulingApp.Application.UseCases.Users.Queries.GetBySearchValue
{
    public class GetUsersBySearchValueHandler : IRequestHandler<GetUsersBySearchValueQuery, Result<UserQueryModel>>
    {
      

        public Task<Result<UserQueryModel>> Handle(GetUsersBySearchValueQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
