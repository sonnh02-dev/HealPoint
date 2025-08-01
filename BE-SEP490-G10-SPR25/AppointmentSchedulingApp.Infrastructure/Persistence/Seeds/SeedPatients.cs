using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedPatients
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, UserManager<IdentityUser<int>> userManager, CancellationToken ct)
        {
            if (await context.Patients.AnyAsync(ct)) return;
            var faker = new Faker("vi");

            var patientAccounts = await userManager.GetUsersInRoleAsync("Bệnh nhân");

            var patients = new List<Patient>();

            for (int i = 0; i < patientAccounts.Count; i++)
            {
                var patient = new Patient
                {
                    Id = patientAccounts[i].Id, 
                    Occupation = faker.Name.JobTitle(),
                    MainCondition = faker.PickRandom(new[] { "Tiểu đường", "Huyết áp cao", "Đau lưng", null }),
                    Rank = faker.PickRandom(new[] { "VIP", "Thường", "Thành viên", null })
                };

                if (i >= 5)
                {
                    var guardian = patients[faker.Random.Int(0, i - 1)];
                    patient.GuardianId = guardian.Id;
                    patient.Relationship = faker.PickRandom(new[] { "Cha", "Mẹ", "Anh", "Chị", "Vợ", "Chồng" });
                }

                patients.Add(patient);
                context.Patients.Add(patient);
            }

            await context.SaveChangesAsync(ct);
        }
    }

}