using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Posts.Queries.GetAll
{
    public class GetPostListQuery : IRequest<Result<IEnumerable<PostQueryModel>>>
    {
    }
}
