using FluentValidation;

namespace AppointmentSchedulingApp.Application.UseCases.Doctors.Commands.Create
{
    internal class CreateDoctorValidator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorValidator()
        {
            RuleFor(c => c.DoctorId)
                .GreaterThan(0).WithMessage("DoctorId phải lớn hơn 0");

            RuleFor(c => c.ServiceId)
                .GreaterThan(0).WithMessage("ServiceId phải lớn hơn 0");

            RuleFor(c => c.RoomId)
                .GreaterThan(0).WithMessage("RoomId phải lớn hơn 0");

            RuleFor(c => c.SlotId)
                .GreaterThan(0).WithMessage("SlotId phải lớn hơn 0");

            RuleFor(c => c.DayOfWeek)
                .NotEmpty().WithMessage("DayOfWeek không được để trống")
                .Must(BeAValidDay).WithMessage("DayOfWeek phải là thứ trong tuần hợp lệ (Monday, Tuesday...)");
        }

        private bool BeAValidDay(string day)
        {
            return Enum.TryParse<DayOfWeek>(day, ignoreCase: true, out _);
        }
    }
}
