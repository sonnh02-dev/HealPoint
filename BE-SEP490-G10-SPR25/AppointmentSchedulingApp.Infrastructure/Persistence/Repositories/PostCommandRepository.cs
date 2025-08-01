using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Repositories
{
    public class PostCommandRepository : GenericCommandRepository<Post>, IPostCommandRepository
    {

        public PostCommandRepository(ApplicationCommandDbContext context) : base(context)
        {
        }
        //public async Task<List<Post>> GetAllPostsWithDetails()
        //{
        //    return await context.Posts
        //        .Include(p => p.PostSections)
        //        .Include(p => p.PostAuthor)
        //            .ThenInclude(d => d.DoctorNavigation)
        //        .ToListAsync();
        //}
        //public async Task<IQueryable<Post>> GetAllPosts()
        //{
        //    return context.Posts.AsQueryable();
        //}
        //public async Task<Post?> GetPostById(int id)
        //{
        //    return await context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
        //}
        //public async Task<Post?> GetPostDetailById(int id)
        //{
        //    return await context.Posts
        //    .Include(p => p.PostSections)
        //    .Include(p => p.Comments) 
        //    .Include(p => p.PostAuthor)
        //        .ThenInclude(d => d.DoctorNavigation)
        //    .FirstOrDefaultAsync(p => p.PostId == id);
        //}
        //public async Task DeletePostAsync(int id)
        //{
        //    var post = await context.Posts
        //        .Include(p => p.PostSections)
        //        .Include(p => p.Comments)
        //        .FirstOrDefaultAsync(p => p.PostId == id);
        //    if (post != null)
        //    {
        //        context.PostSections.RemoveRange(post.PostSections);
        //        context.Comments.RemoveRange(post.Comments);
        //        context.Posts.Remove(post);
        //        await context.SaveChangesAsync();
        //    }
        //}
        //public void DeletePostSection(PostSection section)
        //{
        //    context.PostSections.Remove(section);
        //}
        //public async Task AddPostSectionAsync(PostSection section)
        //{
        //    await context.PostSections.AddAsync(section);
        //}
        //public async Task<int> GetPostSectionsCountAsync()
        //{
        //    return await context.PostSections.CountAsync();
        //}
        //public async Task<List<string>> GetAllPostSectionImageNamesAsync()
        //{
        //    return await context.PostSections
        //        .Where(s => s.PostImageUrl != null && s.PostImageUrl.StartsWith("phan_"))
        //        .Select(s => s.PostImageUrl)
        //        .ToListAsync();
        //}
    }
}
