using AppointmentSchedulingApp.Application.UseCases.Posts.Queries.GetAll;
using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using AppointmentSchedulingApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.Abstractions.Search.Repositories
{
    public interface IPostQueryRepository : IGenericQueryRepository<PostQueryModel>
    {
       
    }
}
