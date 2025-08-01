using AppointmentSchedulingApp.Application.UseCases.Services.Queries.GetAll;
using AppointmentSchedulingApp.Infrastructure.Search.Repositories;
using Elastic.Clients.Elasticsearch;

namespace AppointmentSchedulingApp.Infrastructure.Search.Repository
{
    internal class ServiceQueryRepository : GenericQueryRepository<ServiceQueryModel>
    {
        public ServiceQueryRepository(ElasticsearchClient client) : base(client)
        {
        }
    }
}
