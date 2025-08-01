
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class SpecialtyCommandRepository : GenericCommandRepository<Specialty>, ISpecialtyCommandRepository
    {

        public SpecialtyCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {

        }
    }
}
