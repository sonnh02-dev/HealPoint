using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Feedbacks.Commands.Create
{
    internal class CreateFeedbackHandler : IRequestHandler<CreateFeedbackCommand, Result>
    {
        public Task<Result> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
