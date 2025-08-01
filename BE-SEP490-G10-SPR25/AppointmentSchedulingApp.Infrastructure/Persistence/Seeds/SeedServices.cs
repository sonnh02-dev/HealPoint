using AppointmentSchedulingApp.Domain.AggregatesModel.ServiceAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedServices
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            if (await context.Services.AnyAsync(ct))
                return;

            // Danh sách tên dịch vụ y tế phổ biến
            var serviceNames = new List<string>
            {
                  "Khám tim mạch", "Khám tai mũi họng tổng quát", "Khám mắt",
                  "Xét nghiệm", "Vật lý trị liệu", "Tư vấn tâm lý", "Khám nhi",
                  "Siêu âm", "Khám da liễu", "Tư vấn dinh dưỡng", "Tiêm chủng cho trẻ em",
                  "Chiropractic", "Kiểm tra thính giác chuyên sâu", "Tư vấn dinh dưỡng tiêu hóa",
                  "Khám chỉnh hình", "Tư vấn hiếm muộn", "Tư vấn tiểu đường",
                  "Liệu pháp hô hấp", "Khám tiêu hóa","Khám mạch vành","Khám hô hấp tổng quát",
                  "Khám thần kinh tổng quát","Khám rụng tóc & bệnh lý da đầu","Khám Răng Hàm Mặt"
            };


            var faker = new Faker();

            var services = new List<Service>();

            int specialtyCount = 18; 

            foreach (var name in serviceNames)
            {
                var service = new Service
                {
                    ServiceName = name,
                    Overview = faker.Lorem.Paragraph(2),
                    Process = faker.Lorem.Sentences(3),
                    TreatmentTechniques = faker.Lorem.Sentences(2),
                    Price = faker.Random.Decimal(200_000, 3_000_000), 
                    EstimatedTime = new TimeOnly(faker.Random.Int(0, 2), faker.Random.Int(0, 59)),
                    SpecialtyId = faker.Random.Int(1, specialtyCount),
                    Image = $"dichvu_{serviceNames.IndexOf(name)+1}.jpg"
                };
                services.Add(service);
            }

            await context.Services.AddRangeAsync(services, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
