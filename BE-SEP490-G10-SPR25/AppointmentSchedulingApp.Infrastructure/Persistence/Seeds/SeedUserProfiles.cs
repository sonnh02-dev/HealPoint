using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    public static class SeedUserProfiles
    {
        public static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            if(await context.UserProfiles.AnyAsync(ct)) return;
            var faker = new Faker("vi");
            var users=context.UserAccounts.ToList();
            foreach (var user in users)
            {
                context.UserProfiles.Add(new UserProfile
                {
                    FullName = faker.Name.FullName(),
                    Gender = faker.PickRandom(new[] { "Nam", "Nữ" }),
                    Address = faker.Address.FullAddress(),
                    AvatarUrl = $"user_{user.Id}.jpg",
                    Nationality = "Việt Nam",
                    Dob = DateOnly.FromDateTime(faker.Date.Past(30, DateTime.Today.AddYears(-18))),
                    IsActive = true,
                    IsVerify = false,
                    CitizenId = faker.Random.Long(100000000000, 999999999999),
                });

            }

            await context.SaveChangesAsync(ct);

            

        }
    }

}