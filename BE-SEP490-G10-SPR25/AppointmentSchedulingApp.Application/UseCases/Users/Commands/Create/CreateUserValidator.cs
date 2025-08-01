using FluentValidation;

namespace AppointmentSchedulingApp.Application.UseCases.UsersAccounts.Commands.Create
{
    public class CreateUserValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            //RuleFor(x => x.CustomerId).NotEmpty().NotNull().MinimumLength(5).MaximumLength(5);
            //RuleFor(x => x.ContactName).NotEmpty().NotNull();
            //RuleFor(x => x.Phone).NotEmpty().NotNull();
            //RuleFor(x => x.Region).NotEmpty().NotNull();
        }
    }
}
