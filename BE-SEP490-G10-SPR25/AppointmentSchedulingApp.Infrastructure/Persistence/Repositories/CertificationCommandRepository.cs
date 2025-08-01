using AppointmentSchedulingApp.Domain.AggregatesModel.CertificationAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class CertificationCommandRepository : GenericCommandRepository<Certification>, ICertificationCommandRepository
    {
        public CertificationCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
