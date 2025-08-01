using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Doctors.Commands.Create
{
    public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, Result>
    {
        public Task<Result> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
