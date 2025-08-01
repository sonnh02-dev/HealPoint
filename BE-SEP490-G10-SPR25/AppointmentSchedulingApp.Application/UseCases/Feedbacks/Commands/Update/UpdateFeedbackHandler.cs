using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Feedbacks.Commands.Update
{
    internal class UpdateFeedbackHandler : IRequestHandler<UpdateFeedbackCommand, Result>
    {
        public Task<Result> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
