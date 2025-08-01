using AppointmentSchedulingApp.Application.UseCases.Appointments.Queries.GetAppointmentsByPatientIdAndFilter;
using AppointmentSchedulingApp.Infrastructure.Search.Repositories;
using Elastic.Clients.Elasticsearch;

namespace AppointmentSchedulingApp.Infrastructure.Search.Repository
{
    internal class AppointmentQueryRepository : GenericQueryRepository<AppointmentQueryModel>
    {
        public AppointmentQueryRepository(ElasticsearchClient client) : base(client)
        {
        }
    }
}
