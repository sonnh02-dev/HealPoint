using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSchedulingApp.Infrastructure.Data.Seeds
{
    internal class SeedPosts
    {
        internal static async Task SeedAsync(ApplicationCommandDbContext context, CancellationToken ct)
        {
            if (await context.Posts.AnyAsync(ct)) return;

            if (await context.Posts.AnyAsync(ct)) return;

            var faker = new Faker("vi");

            var userProfiles = await context.UserProfiles.ToListAsync(ct);

            var posts = new List<Post>();

            for (int i = 0; i < 30; i++)
            {
                var author = faker.PickRandom(userProfiles);

                var post = new Post
                {
                    PostAuthorId = author.Id,
                    PostTitle = faker.Lorem.Sentence(6, 4),
                    PostDescription = faker.Lorem.Paragraphs(2),
                    PostCreatedDate = faker.Date.Past(1),
                    PostSourceUrl = faker.Internet.Url(),
                };

                posts.Add(post);
            }

            await context.Posts.AddRangeAsync(posts, ct);
            await context.SaveChangesAsync(ct);
        }
    }
}
