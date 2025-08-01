using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class DoctorScheduleCommandRepository : GenericCommandRepository<DoctorSchedule>, IDoctorScheduleCommandRepository
	{
        public DoctorScheduleCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
