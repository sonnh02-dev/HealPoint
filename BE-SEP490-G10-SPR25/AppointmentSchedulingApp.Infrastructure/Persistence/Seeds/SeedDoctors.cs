using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedDoctors
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, UserManager<IdentityUser<int>> userManager,CancellationToken ct)
        {
            if (await context.Doctors.AnyAsync(ct)) return;

            var faker = new Faker("vi");

            var doctorAccounts  = await userManager.GetUsersInRoleAsync("Bác sĩ");


            var doctors = new List<Doctor>();

            foreach (var acc in doctorAccounts)
            {
                var doctor = new Doctor
                {
                    Id = acc.Id, 
                    CurrentWork = faker.Company.CompanyName(),
                    DoctorDescription = faker.Lorem.Sentences(2),
                    Organization = faker.Company.CompanyName(),
                    Prize = faker.Lorem.Sentence(),
                    ResearchProject = faker.Lorem.Sentence(),
                    TrainingProcess = faker.Lorem.Paragraph(),
                    WorkExperience = $"{faker.Random.Int(1, 30)} năm",
                    AcademicTitle = faker.PickRandom(new[] { "Phó Giáo sư", "Tiến sĩ", "Giảng viên", "Bác sĩ CKII" }),
                    Degree = faker.PickRandom(new[] { "Đại học Y Hà Nội", "Đại học Y Dược TP.HCM", "Học viện Quân y" }),
                    //Rating = Math.Round(faker.Random.Double(3.5, 5.0), 1),
                    //RatingCount = faker.Random.Int(5, 100)
                };

                doctors.Add(doctor);
                context.Doctors.Add(doctor);
            }


            await context.SaveChangesAsync(ct);
        }
    }

}