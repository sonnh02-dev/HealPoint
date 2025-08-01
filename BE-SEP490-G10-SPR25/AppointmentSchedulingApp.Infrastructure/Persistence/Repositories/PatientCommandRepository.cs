using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class PatientCommandRepository : GenericCommandRepository<Patient>, IPatientCommandRepository
    {
        public PatientCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
