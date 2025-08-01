using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;

using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.CommentAggregate;

public partial class Comment:Entity
{
    public int CommentId { get; set; }

    public string Content { get; set; } = null!;

    public int PatientId { get; set; }

    public int PostId { get; set; }

    public DateTime CommentOn { get; set; }

    public int? RepliedCommentId { get; set; }

    public int NumberOfLikes { get; set; }

    public  Post Post { get; set; } = null!;

    public Patient Patient { get; set; }
}
