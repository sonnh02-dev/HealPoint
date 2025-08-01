using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class DbSeeder
    {
        public static async Task SeedAsync(ApplicationCommandDbContext context, IServiceProvider services, CancellationToken ct)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser<int>>>();
            var roleManager= services.GetRequiredService<RoleManager<IdentityRole<int>>>();

            await SeedUserAccounts.SeedAsync(userManager, ct);
            await SeedRoles.SeedAsync(roleManager,ct);
            await SeedUserRoles.SeedAsync(userManager, ct);

            await SeedUserProfiles.SeedAsync(context, ct);
            await SeedPatients.SeedAsync(context, userManager, ct);
            await SeedDoctors.SeedAsync(context, userManager, ct);
            await SeedReceptionists.SeedAsync(context, userManager, ct);

            await SeedCertifications.SeedAsync(context, userManager, ct);
            await SeedPosts.SeedAsync(context, ct);
            await SeedPostSections.SeedAsync(context, ct);


            await SeedSpecialties.SeedAsync(context, ct);
            await SeedServices.SeedAsync(context, ct);
            await SeedSlots.SeedAsync(context, ct);
            await SeedRooms.SeedAsync(context, ct);
            await SeedDoctorSchedules.SeedAsync(context, ct);
            await SeedAppointments.SeedAsync(context, userManager, ct);
            await SeedPayments.SeedAsync(context, ct);
            await SeedMedicalRecords.SeedAsync(context, ct);
            await SeedFeedbacks.SeedAsync(context, ct);

        }
    }
}
