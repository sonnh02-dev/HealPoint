using AppointmentSchedulingApp.SharedKernel;
using AutoMapper;

using MediatR;

namespace AppointmentSchedulingApp.Application.UseCases.UsersAccounts.Commands.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<bool>>
    {
        public Task<Result<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
