using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentSchedulingApp.Domain.AggregatesModel.RoomAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class RoomCommandRepository : GenericCommandRepository<Room>, IRoomCommandRepository
	{
        public RoomCommandRepository(ApplicationCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
