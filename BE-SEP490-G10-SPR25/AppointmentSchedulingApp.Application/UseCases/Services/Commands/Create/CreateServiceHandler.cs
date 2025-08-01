using AppointmentSchedulingApp.Application.UseCases.Services.Commands.Create;
using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Services.Commands.Add
{
    public class CreateCommentHandler : IRequestHandler<CreateSpecialtyCommand, Result>
    {
        public Task<Result> Handle(CreateSpecialtyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
