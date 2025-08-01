using AutoMapper;
using AppointmentSchedulingApp.SharedKernel;

using MediatR;

namespace AppointmentSchedulingApp.Application.UseCases.Users.Commands.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Result<bool>>
    {
        public Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
