using AppointmentSchedulingApp.Domain.AggregatesModel.ReceptionistAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    public static class SeedReceptionists
    {
        public static async Task SeedAsync(ApplicationCommandDbContext context, UserManager<IdentityUser<int>> userManager, CancellationToken ct)
        {
            if (await context.Receptionists.AnyAsync(ct)) return;

            var faker = new Faker("vi");
            var receptionists = new List<Receptionist>();
            var receptionistAccounts =await userManager.GetUsersInRoleAsync("Tiếp tân"); 

            foreach (var acc in receptionistAccounts)
            {
                var receptionist = new Receptionist
                {
                    Id = acc.Id,
                    StartDate = DateOnly.FromDateTime(faker.Date.Past(5)),
                    Shift = faker.PickRandom(new[] { "Sáng", "Chiều" }),
                };

                receptionists.Add(receptionist);
            }

            context.Receptionists.AddRange(receptionists);
            await context.SaveChangesAsync(ct);
        }
    }
}
