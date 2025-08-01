
using System.Threading.Tasks;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class ReservationCommandRepository : GenericCommandRepository<Appointment>, IAppointmentCommandRepository
	{
        public ReservationCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }

       
    }
}