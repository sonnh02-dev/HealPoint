using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Payments.Commands.Update
{
    public class UpdatePaymentHandler : IRequestHandler<UpdatePaymentCommand, Result>
    {
        public Task<Result> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
