using AppointmentSchedulingApp.Domain.AggregatesModel.RoomAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedRooms
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            var faker = new Faker("vi");
            var roomTypes = new[] {
                 "Hồi sức tích cực", "Chụp X-quang", "Chụp MRI", "Chụp CT", "Phẫu thuật",
                 "Khám bệnh", "Siêu âm", "Xét nghiệm", "Cấp cứu", "Nội soi", "Chạy thận nhân tạo"
           };
            var roomList = new List<Room>();

            for (int i = 321; i <= 340; i++)
            {
                var khu = faker.PickRandom(new[] { "Khu A", "Khu B", "Khu C", "Khu D", "Khu E", "Khu F" });
                var room = new Room {
                    RoomName= $"Phòng {i}",
                    RoomType= faker.PickRandom(roomTypes),
                    Location= $"Tầng 3, {khu}"
                };
                roomList.Add(room);
            }
            await context.Rooms.AddRangeAsync(roomList, ct);
        }
    }
}