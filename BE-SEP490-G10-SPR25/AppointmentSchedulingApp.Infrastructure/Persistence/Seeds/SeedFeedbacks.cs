using AppointmentSchedulingApp.Domain.AggregatesModel.FeedbackAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedFeedbacks
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            if (await context.Feedbacks.AnyAsync(ct)) return;

            var faker = new Faker("vi");

            var completedAppointments = await context.Appointments.Where(a =>  a.Status == "Hoàn thành") .ToListAsync(ct);

            var feedbacks = new List<Feedback>();

            foreach (var appointment in completedAppointments)
            {
                var feedback = new Feedback
                {
                    Id = appointment.Id,
                    ServiceFeedbackContent = faker.Lorem.Sentences(1),
                    ServiceFeedbackGrade = faker.Random.Bool(0.8f) ? faker.Random.Int(1, 5) : null,
                    DoctorFeedbackContent = faker.Lorem.Sentences(1),
                    DoctorFeedbackGrade = faker.Random.Bool(0.8f) ? faker.Random.Int(1, 5) : null,
                    FeedbackDate = appointment.AppointmentDate.AddDays(faker.Random.Int(0, 5))
                };

                feedbacks.Add(feedback);
            }

            await context.Feedbacks.AddRangeAsync(feedbacks, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
