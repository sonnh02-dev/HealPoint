using AppointmentSchedulingApp.Domain.AggregatesModel.CertificationAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedCertifications
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context,UserManager<IdentityUser<int>> userManager, CancellationToken ct)
        {
            if (await context.Certifications.AnyAsync(ct)) return;

            var faker = new Faker("vi");

            var doctorAccounts = await userManager.GetUsersInRoleAsync("Bác sĩ");


            var certifications = new List<Certification>();

            foreach (var doctor in doctorAccounts)
            {
                int certCount = faker.Random.Int(1, 5);

                for (int i = 0; i < certCount; i++)
                {
                    certifications.Add(new Certification
                    {
                        DoctorId = doctor.Id,
                        CertificationUrl = $"cert_doctor_{doctor.Id}_{i + 1}.jpg" 
                    });
                }
            }

            context.Certifications.AddRange(certifications);
            await context.SaveChangesAsync(ct);
        }
    }

}