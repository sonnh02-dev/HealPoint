using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using AppointmentSchedulingApp.Domain.AggregatesModel.SlotAggregate;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedSlots
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            if (await context.Slots.AnyAsync(ct))
                return;

            var slotId = 1;
            var startTime = new TimeOnly(7, 30);
            var slotDuration = TimeSpan.FromMinutes(60);
            var breakTime = TimeSpan.FromMinutes(10);

            var faker = new Faker();

            var slots = new List<Slot>();

            for (int i = 0; i < 8; i++)
            {
                var endTime = startTime.AddMinutes(slotDuration.TotalMinutes);

                slots.Add(new Slot
                {
                    Id = slotId++,
                    SlotStartTime = startTime,
                    SlotEndTime = endTime
                });

                // Update start time for next slot
                startTime = endTime.Add(breakTime);
            }

            await context.Slots.AddRangeAsync(slots, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
