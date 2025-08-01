using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    public static class SeedUserRoles
    {
        public static async Task SeedAsync( UserManager<IdentityUser<int>> userManager, CancellationToken ct)
        {
            if (await AreUserRolesSeededAsync(userManager)) return;

            async Task AssignRole(string role, int start, int? end = null)
            {
                end ??= start;
                for (int i = start; i <= end; i++)
                {
                    var user = await userManager.FindByNameAsync($"user{i}");
                    if (user != null)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }

            await AssignRole("Bệnh nhân", 1, 30);
            await AssignRole("Tiếp tân", 31, 32);
            await AssignRole("Bác sĩ", 33, 52);
            await AssignRole("Quản trị viên", 53);


        }
        public static async Task<bool> AreUserRolesSeededAsync(UserManager<IdentityUser<int>> userManager)
        {
            for (int i = 1; i <= 5; i++) 
            {
                var user = await userManager.FindByNameAsync($"user{i}");
                if (user == null) continue;

                var roles = await userManager.GetRolesAsync(user);
                if (roles == null || roles.Count == 0)
                {
                    return false; 
                }
            }

            return true; 
        }

    }
}
