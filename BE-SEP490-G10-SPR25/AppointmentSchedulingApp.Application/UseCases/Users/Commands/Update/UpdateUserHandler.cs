
using AppointmentSchedulingApp.SharedKernel;
using MediatR;

namespace AppointmentSchedulingApp.Application.UseCases.Users.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        public Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
