using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Bogus.DataSets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    public static class SeedUserAccounts
    {
        public static async Task SeedAsync(UserManager<IdentityUser<int>> userManager, CancellationToken ct)
        {
            if (await userManager.Users.AnyAsync(ct)) return;

            var faker = new Faker("vi");

            for (int i = 1; i <= 53; i++)
            {

                var user = new IdentityUser<int>
                {
                    UserName = $"user{i}",
                    Email = $"user{i}@gmail.com",
                    PhoneNumber = faker.Phone.PhoneNumber(),
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "P@ssword123");

            }


        }
    }

}