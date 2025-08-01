using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class UserProfileCommandRepository : GenericCommandRepository<UserProfile>, IUserProfileCommandRepository
	{
        public UserProfileCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
