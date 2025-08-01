
using AppointmentSchedulingApp.SharedKernel;
using MediatR;

namespace AppointmentSchedulingApp.Application.UseCases.Users.Commands.Delete
{
    public class DeleteUserCommand: IRequest<Result<bool>>
    {
        public string CustomerId { get; set; }
    }
}
