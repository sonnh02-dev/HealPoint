using AppointmentSchedulingApp.Application.UseCases.Doctors.Queries.GetByFilter;
using AppointmentSchedulingApp.Infrastructure.Search.Repositories;
using Elastic.Clients.Elasticsearch;

namespace AppointmentSchedulingApp.Infrastructure.Search.Repository
{
    internal class DoctorQueryRepository : GenericQueryRepository<DoctorQueryModel>
    {
        public DoctorQueryRepository(ElasticsearchClient client) : base(client)
        {
        }
    }
}
