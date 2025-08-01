using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;

using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.FeedbackAggregate;

public partial class Feedback:Entity
{

    public int AppointmentId { get; set; }

    public string ServiceFeedbackContent { get; set; } = null!;

    public int? ServiceFeedbackGrade { get; set; }

    public string DoctorFeedbackContent { get; set; } = null!;

    public int? DoctorFeedbackGrade { get; set; }

    public DateTime FeedbackDate { get; set; }

    public  Appointment Appointment { get; set; } = null!;
}
