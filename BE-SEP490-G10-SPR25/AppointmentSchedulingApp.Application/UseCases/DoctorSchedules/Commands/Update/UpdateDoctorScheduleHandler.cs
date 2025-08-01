using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.DoctorSchedules.Commands.Update
{
    public class DeleteDoctorHandler : IRequestHandler<UpdateDoctorCommand, Result>
    {
        public Task<Result> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
