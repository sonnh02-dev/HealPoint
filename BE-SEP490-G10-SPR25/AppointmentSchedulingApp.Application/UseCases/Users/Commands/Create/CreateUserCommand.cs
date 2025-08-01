
using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulingApp.Application.UseCases.UsersAccounts.Commands.Create
{
    public class CreateUserCommand: IRequest<Result<bool>>
    {
        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; }
        public string? UserName { get; set; }
      
        public string? Password { get; set; }

       
        public string? ConfirmPassword { get; set; }


        public int[] RoleIds { get; set; }=new int[0];

    }
}
