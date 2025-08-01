using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Posts.Queries.GetAll
{
    public class  PostQueryModel
    {
        [Key]
        public int PostId { get; set; }

        public string PostTitle { get; set; }

        public string PostDescription { get; set; }

        public DateTime PostCreatedDate { get; set; }

        public string PostSourceUrl { get; set; } = "";

        public string? AuthorName { get; set; }
        public string? PostImageUrl { get; set; }
        public int? AuthorId { get; set; }

    }



}
