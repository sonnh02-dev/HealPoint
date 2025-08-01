using AppointmentSchedulingApp.Domain.AggregatesModel.ReceptionistAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class ReceptionistCommandRepository : GenericCommandRepository<Receptionist>, IReceptionistCommandRepository
	{
        public ReceptionistCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
