using AppointmentSchedulingApp.Application.UseCases.Comments.Queries.GetByPostId;
using AppointmentSchedulingApp.Application.UseCases.Posts.Queries.GetAll;
using AppointmentSchedulingApp.Application.UseCases.Services.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Posts.Queries.GetById
{
    public class PostDetailQueryModel : PostQueryModel
    {
        public string? PostImageUrl { get; set; }

        public string? PostCategory { get; set; }

        public string? AuthorBio { get; set; }
        public List<PostSectionQueryModel> PostSections { get; set; } = new();
        public List<CommentQueryModel> Comments { get; set; } = new();
    }
}
