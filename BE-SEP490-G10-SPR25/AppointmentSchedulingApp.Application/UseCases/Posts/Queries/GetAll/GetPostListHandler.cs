using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Posts.Queries.GetAll
{
    public class GetPostListHandler : IRequestHandler<GetPostListQuery, Result<IEnumerable<PostQueryModel>>>
    {
        public Task<Result<IEnumerable<PostQueryModel>>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
