using AppointmentSchedulingApp.Application.UseCases.Posts.Commands.Create;
using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Posts.Commands.Add
{
    public class CreateCommentHandler : IRequestHandler<CreatePostCommand, Result>
    {
        public Task<Result> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
