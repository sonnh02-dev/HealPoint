using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Specialties.Commands.Update
{
    internal class UpdateSpecialtyHandler : IRequestHandler<UpdateSpecialtyCommand, Result>
    {
        public Task<Result> Handle(UpdateSpecialtyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
