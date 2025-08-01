using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Posts.Commands.Delete
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, Result>
    {
        public Task<Result> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
