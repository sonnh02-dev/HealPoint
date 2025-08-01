
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class ServiceCommandRepository : GenericCommandRepository<Service>, IServiceCommandRepository
    {

        public ServiceCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IQueryable<Service>> GetServicesBySpecialty(int specialtyId)
        {
            return _dbContext.Services.Where(s => s.SpecialtyId == specialtyId).AsQueryable();
        }
    }
}
