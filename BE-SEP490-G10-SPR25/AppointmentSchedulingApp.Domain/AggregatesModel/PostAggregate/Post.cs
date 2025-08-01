using AppointmentSchedulingApp.Domain.AggregatesModel.CommentAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;

public partial class Post:Entity
{
    public int PostId { get; set; }

    public int PostAuthorId { get; set; }

    public string PostTitle { get; set; } = null!;

    public string PostDescription { get; set; } = null!;

    public DateTime PostCreatedDate { get; set; }

    public string? PostSourceUrl { get; set; }

    public  ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public UserProfile PostAuthor { get; set; }

    public  ICollection<PostSection> PostSections { get; set; } = new List<PostSection>();
}
