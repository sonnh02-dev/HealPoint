using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Doctors.Commands.Delete
{
    public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand, Result>
    {
        public Task<Result> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
