using AppointmentSchedulingApp.Application.UseCases.Comments.Queries.GetByPostId;
using AppointmentSchedulingApp.Domain.Commons;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.Abstractions.Search.Repositories
{
    public interface ICommentQueryRepository : IGenericQueryRepository<CommentQueryModel>
    {
       
    }
}
