using AppointmentSchedulingApp.Domain.AggregatesModel.PaymentAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedPayments
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            if (await context.Payments.AnyAsync(ct)) return;

            var faker = new Faker("vi");

            var patients = await context.Patients.ToListAsync(ct);
            var receptionists = await context.Receptionists.ToListAsync(ct);
            var appointments = await context.Appointments.ToListAsync(ct);

            var paymentMethods = new[] { "Tiền mặt", "Chuyển khoản", "Thẻ tín dụng" };
            var paymentStatuses = new[] { "Đã thanh toán", "Đã hoàn tiền", "Đang xử lý" };

            var payments = new List<Payment>();

            for (int i = 0; i < 50; i++)
            {
                var payer = faker.PickRandom(patients);
                var receptionist = faker.Random.Bool(0.5f) ? faker.PickRandom(receptionists) : null; // 50% có tiếp tân xử lý
                var appointment = faker.PickRandom(appointments);

                var paymentDate = faker.Date.Between(DateTime.Now.AddMonths(-3), DateTime.Now);

                var payment = new Payment
                {
                    PayerId = payer.Id,
                    PaymentDate = paymentDate,
                    ReceptionistId = receptionist?.Id,
                    PaymentMethod = faker.PickRandom(paymentMethods),
                    PaymentStatus = faker.PickRandom(paymentStatuses),
                    TransactionId = faker.Random.AlphaNumeric(10).ToUpper(),
                    Amount = faker.Finance.Amount(100000, 2000000),
                };

                payments.Add(payment);
            }

            await context.Payments.AddRangeAsync(payments, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
