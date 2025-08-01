using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorScheduleAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Bogus;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedDoctorSchedules
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            if (await context.DoctorSchedules.AnyAsync(ct)) return;

            var faker = new Faker("vi");

            var doctors = await context.Doctors.ToListAsync(ct);
            var services = await context.Services.ToListAsync(ct);
            var slots = await context.Slots.ToListAsync(ct);
            var rooms = await context.Rooms.ToListAsync(ct);

            var daysOfWeek = new[] { "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu" };

            var schedules = new List<DoctorSchedule>();

            foreach (var doctor in doctors)
            {
                int scheduleCount = faker.Random.Int(3, 6); 

                for (int i = 0; i < scheduleCount; i++)
                {
                    var schedule = new DoctorSchedule
                    {
                        DoctorId = doctor.Id,
                        ServiceId = faker.PickRandom(services).Id,
                        DayOfWeek = faker.PickRandom(daysOfWeek),
                        RoomId = faker.PickRandom(rooms).Id,
                        SlotId = faker.PickRandom(slots).Id
                    };

                    schedules.Add(schedule);
                }
            }

            await context.DoctorSchedules.AddRangeAsync(schedules, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
