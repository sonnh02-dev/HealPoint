using AppointmentSchedulingApp.Domain.Commons;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate
{
	public interface IUserProfileCommandRepository : IGenericCommandRepository<UserProfile>
	{
	}
}
