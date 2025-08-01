using AppointmentSchedulingApp.Application.UseCases.Appointments.Queries.GetAppointmentsByPatientIdAndFilter;
using AppointmentSchedulingApp.Application.UseCases.Feedbacks.Queries.GetByDoctorId;
using AppointmentSchedulingApp.Infrastructure.Search.Repositories;
using Elastic.Clients.Elasticsearch;

namespace AppointmentSchedulingApp.Infrastructure.Search.Repository
{
    internal class DoctorFeedbackQueryRepository : GenericQueryRepository<DoctorFeedbackQueryModel>
    {
        public DoctorFeedbackQueryRepository(ElasticsearchClient client) : base(client)
        {
        }
    }
}
