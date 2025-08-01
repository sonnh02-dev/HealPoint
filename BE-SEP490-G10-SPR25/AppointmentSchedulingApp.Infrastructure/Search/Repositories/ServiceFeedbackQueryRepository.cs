using AppointmentSchedulingApp.Application.UseCases.Appointments.Queries.GetAppointmentsByPatientIdAndFilter;
using AppointmentSchedulingApp.Application.UseCases.Feedbacks.Queries.GetByServiceId;
using AppointmentSchedulingApp.Infrastructure.Search.Repositories;
using Elastic.Clients.Elasticsearch;

namespace AppointmentSchedulingApp.Infrastructure.Search.Repository
{
    internal class ServiceFeedbackQueryRepository : GenericQueryRepository<ServiceFeedbackQueryModel>
    {
        public ServiceFeedbackQueryRepository(ElasticsearchClient client) : base(client)
        {
        }
    }
}
