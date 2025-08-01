using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.DoctorSchedules.Commands.Update
{
    internal class DeleteDoctorValidator:AbstractValidator<UpdateDoctorCommand>
    {
        public DeleteDoctorValidator()
        {
            RuleFor(u => u.DoctorId)
               .GreaterThan(0).WithMessage("DoctorId phải lớn hơn 0");

            RuleFor(u => u.ServiceId)
                .GreaterThan(0).WithMessage("ServiceId phải lớn hơn 0");

            RuleFor(u => u.RoomId)
                .GreaterThan(0).WithMessage("RoomId phải lớn hơn 0");

            RuleFor(u => u.SlotId)
                .GreaterThan(0).WithMessage("SlotId phải lớn hơn 0");

            RuleFor(u => u.DayOfWeek)
                .NotEmpty().WithMessage("DayOfWeek không được để trống")
                .Must(BeAValidDay).WithMessage("DayOfWeek phải là thứ trong tuần hợp lệ (Monday, Tuesday...)");
        }

        private bool BeAValidDay(string day)
        {
            return Enum.TryParse<DayOfWeek>(day, ignoreCase: true, out _);
        }
    }
}
