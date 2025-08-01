using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Posts.Queries.GetById
{
    public class PostSectionQueryModel
    {
        public string SectionTitle { get; set; }
        public string SectionContent { get; set; }
        public int SectionIndex { get; set; }
        public string? PostImageUrl { get; set; }
    }
}
