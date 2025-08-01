
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using AppointmentSchedulingApp.Domain.AggregatesModel.MedicalRecordAggregate;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class MedicalRecordCommandRepository : GenericCommandRepository<MedicalRecord>, IMedicalRecordCommandRepository
    {
        public MedicalRecordCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
