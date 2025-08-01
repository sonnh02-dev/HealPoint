using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Commands.Update
{
    internal class UpdateMedicalRecordValidator : AbstractValidator<UpdateMedicalRecordCommand>
    {
        public UpdateMedicalRecordValidator()
        {
            //RuleFor(u => u.DoctorId)
            //   .GreaterThan(0).WithMessage("DoctorId phải lớn hơn 0");

           
        }

       
    }
}
