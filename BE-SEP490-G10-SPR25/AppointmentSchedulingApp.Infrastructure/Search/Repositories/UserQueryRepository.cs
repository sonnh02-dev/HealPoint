using AppointmentSchedulingApp.Application.UseCases.Users.Queries.GetBySearchValue;
using AppointmentSchedulingApp.Infrastructure.Search.Repositories;
using Elastic.Clients.Elasticsearch;

namespace AppointmentSchedulingApp.Infrastructure.Search.Repository
{
    public class UserQueryRepository : GenericQueryRepository<UserQueryModel>
    {
        public UserQueryRepository(ElasticsearchClient client) : base(client)
        {
        }
    }
}
