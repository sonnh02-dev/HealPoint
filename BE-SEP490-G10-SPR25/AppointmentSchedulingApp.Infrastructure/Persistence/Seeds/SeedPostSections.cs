using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedPostSections
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            if (await context.PostSections.AnyAsync(ct)) return;

            var faker = new Faker("vi");

            var posts = await context.Posts.ToListAsync(ct);
            var postSections = new List<PostSection>();

            foreach (var post in posts)
            {
                var sectionCount = faker.Random.Int(1, 3);

                for (int i = 0; i < sectionCount; i++)
                {
                    var section = new PostSection
                    {
                        PostId = post.Id,
                        SectionTitle = faker.PickRandom(new[]
                        {
                            "Giới thiệu", "Nguyên nhân", "Triệu chứng", "Cách phòng ngừa", "Điều trị", "Lưu ý", "Kết luận"
                        }),
                        SectionContent = faker.Lorem.Paragraphs(2),
                        SectionIndex = i + 1,
                        PostImageUrl = faker.Random.Bool(0.3f) ? faker.Image.PicsumUrl() : null
                    };

                    postSections.Add(section);
                }
            }

            await context.PostSections.AddRangeAsync(postSections, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
