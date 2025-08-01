using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedAppointments
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, UserManager<IdentityUser<int>> userManager, CancellationToken ct)
        {
            if (await context.Appointments.AnyAsync(ct))  return;

            var faker = new Faker("vi");

            var patients = await context.Patients.ToListAsync(ct);
            var schedules = await context.DoctorSchedules.ToListAsync(ct);

            var users =userManager.GetUsersInRoleAsync("Bệnh nhân").Result.Concat( userManager.GetUsersInRoleAsync("Tiếp tân").Result).Distinct().ToList();

            var statuses = new[] { "Đang chờ", "Xác nhận", "Không đến", "Hoàn thành", "Đã hủy", };
            var cancellationReasons = new[] { "Bệnh đột xuất", "Không sắp xếp được lịch", "Không đến" };

            var appointments = new List<Appointment>();

            for (int i = 0; i < 50; i++)
            {
                var patient = faker.PickRandom(patients);
                var schedule = faker.PickRandom(schedules);
                var creator = faker.PickRandom(users);
                var updater = faker.PickRandom(users);
                var status = faker.PickRandom(statuses);

                var appointmentDateTime = faker.Date.Between(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(30));

                var appointment = new Appointment
                {
                    PatientId = patient.Id,
                    DoctorScheduleId = schedule.Id,
                    Reason = faker.Lorem.Sentence(),
                    PriorExaminationImg = null,
                    AppointmentDate = appointmentDateTime,
                    Status = status,
                    CancellationReason = status == "Đã hủy" ? faker.PickRandom(cancellationReasons) : null,
                    CreatedAt = appointmentDateTime.AddHours(-faker.Random.Int(1, 48)),
                    CreatorId = creator.Id,
                    ModifiedAt = appointmentDateTime,
                    ModifierId = updater.Id
                };

                appointments.Add(appointment);
            }

            await context.Appointments.AddRangeAsync(appointments, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
