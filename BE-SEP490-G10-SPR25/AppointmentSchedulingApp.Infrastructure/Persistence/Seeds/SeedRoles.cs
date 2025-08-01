using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    public static class SeedRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole<int>> roleManager, CancellationToken ct)
        {
            if (await roleManager.Roles.AnyAsync(ct)) return;

            string[] roles = { "Bệnh nhân", "Bác sĩ", "Tiếp tân", "Quản trị viên" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole<int> { Name = role });
                }
            }
        }
    }

}