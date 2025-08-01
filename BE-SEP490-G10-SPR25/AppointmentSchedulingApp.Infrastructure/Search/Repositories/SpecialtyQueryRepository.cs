using AppointmentSchedulingApp.Application.UseCases.Specialties.Queries.GetAll;
using AppointmentSchedulingApp.Infrastructure.Search.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elastic.Clients.Elasticsearch;

namespace AppointmentSchedulingApp.Infrastructure.Search.Repository
{
    public class SpecialtyQueryRepository : GenericQueryRepository<SpecialtyQueryModel>
    {
        public SpecialtyQueryRepository(ElasticsearchClient client) : base(client)
        {
        }
    }
}
