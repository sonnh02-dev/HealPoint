using AppointmentSchedulingApp.Domain.AggregatesModel.SpecialtyAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedSpecialties
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            if (await context.Specialties.AnyAsync(ct)) return;

            var faker = new Faker("vi");

            var specialtyNames = new[]
            {
                "Nội tổng quát",
                "Tim mạch",
                "Nội tiết",
                "Tiêu hóa",
                "Ngoại tổng quát",
                "Ngoại thần kinh",
                "Chấn thương chỉnh hình",
                "Sản khoa",
                "Phụ khoa",
                "Nhi khoa",
                "Nhãn khoa",
                "Tai - Mũi - Họng",
                "Da liễu",
                "Tâm thần",
                "Xét nghiệm y học",
                "Hồi sức cấp cứu",
                "Hô hấp",
                "Răng Hàm Mặt"
            };

            var specialties = specialtyNames.Select((name, index) => new Specialty
            {
                SpecialtyName = name,
                SpecialtyDescription = faker.Lorem.Sentence(faker.Random.Int(15, 20)),
                Image = $"chuyenkhoa_{index}.jpg"
            }).ToList();

            await context.Specialties.AddRangeAsync(specialties, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
