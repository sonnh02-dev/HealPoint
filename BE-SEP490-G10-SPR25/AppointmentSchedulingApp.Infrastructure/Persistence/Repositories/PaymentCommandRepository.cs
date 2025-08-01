using AppointmentSchedulingApp.Domain.AggregatesModel.PaymentAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class PaymentCommandRepository : GenericCommandRepository<Payment>, IPaymentCommandRepository
	{
        public PaymentCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
