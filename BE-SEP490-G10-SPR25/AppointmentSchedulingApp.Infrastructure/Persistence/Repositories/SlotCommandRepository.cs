using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentSchedulingApp.Domain.AggregatesModel.SlotAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class SlotCommandRepository : GenericCommandRepository<Slot>, ISlotCommandRepository
	{
        public SlotCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
