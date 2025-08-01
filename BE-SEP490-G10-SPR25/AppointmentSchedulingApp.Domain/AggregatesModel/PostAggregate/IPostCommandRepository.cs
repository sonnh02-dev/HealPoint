using AppointmentSchedulingApp.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate
{
    public interface IPostCommandRepository : IGenericCommandRepository<Post>
    {
        //Task<List<Post>> GetAllPostsWithDetails();
        //Task<IQueryable<Post>> GetAllPosts();
        //Task<Post?> GetPostById(int id);
        //Task<Post?> GetPostDetailById(int id);
        //Task DeletePostAsync(int id);
        //Task<int> GetPostSectionsCountAsync();
        //void DeletePostSection(PostSection section);
        //Task AddPostSectionAsync(PostSection section);
        //Task<List<string>> GetAllPostSectionImageNamesAsync();
    }
}
