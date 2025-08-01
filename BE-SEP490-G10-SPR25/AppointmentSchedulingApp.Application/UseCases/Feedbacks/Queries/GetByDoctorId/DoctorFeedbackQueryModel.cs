using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Feedbacks.Queries.GetByDoctorId
{
    public  class DoctorFeedbackQueryModel
    {
        [Key]
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientImage { get; set; }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public int DoctorFeedbackGrade { get; set; }
        public string DoctorFeedbackContent { get; set; } = null!;


        public DateTime FeedbackDate { get; set; }
    }
}
