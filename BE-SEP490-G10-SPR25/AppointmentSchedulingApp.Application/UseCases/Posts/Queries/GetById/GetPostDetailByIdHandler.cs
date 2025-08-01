using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Posts.Queries.GetById
{
    public class GetPostDetailByIdHandler : IRequestHandler<GetPostDetailByIdQuery, Result<PostDetailQueryModel>>
    {
        public Task<Result<PostDetailQueryModel>> Handle(GetPostDetailByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
