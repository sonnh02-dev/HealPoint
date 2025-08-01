using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Doctors.Commands.Delete
{
    internal class DeleteDoctorValidator:AbstractValidator<DeleteDoctorCommand>
    {
        public DeleteDoctorValidator()
        {
            RuleFor(c => c.DoctorId).NotEmpty();

        }

       
    }
}
