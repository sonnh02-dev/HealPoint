using AppointmentSchedulingApp.Domain.AggregatesModel.MedicalRecordAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedMedicalRecords
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            if (await context.MedicalRecords.AnyAsync(ct))  return;

            var faker = new Faker("vi");

            var appointments = await context.Appointments.ToListAsync(ct);

            var medicalRecords = new List<MedicalRecord>();

            foreach (var appointment in appointments)
            {
                var createdAt = faker.Date.Between(appointment.AppointmentDate.AddDays(-7), appointment.AppointmentDate.AddDays(7));

                var record = new MedicalRecord
                {
                    Id = appointment.Id,
                    Symptoms = faker.Random.Bool(0.8f) ? faker.Lorem.Sentence(5, 10) : null,
                    Diagnosis = faker.Lorem.Sentence(3, 7),
                    TreatmentPlan = faker.Lorem.Paragraph(1),
                    FollowUpDate = faker.Random.Bool(0.4f) ? faker.Date.Between(appointment.AppointmentDate.AddDays(1), appointment.AppointmentDate.AddMonths(1)) : null,
                    Notes = faker.Random.Bool(0.3f) ? faker.Lorem.Sentence() : null,
                    CreatedAt = createdAt
                };

                medicalRecords.Add(record);
            }

            await context.MedicalRecords.AddRangeAsync(medicalRecords, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
