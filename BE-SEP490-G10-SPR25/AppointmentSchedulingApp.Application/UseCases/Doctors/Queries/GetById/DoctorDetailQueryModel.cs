using AppointmentSchedulingApp.Application.UseCases.Doctors.Queries.GetByFilter;
using AppointmentSchedulingApp.Application.UseCases.DoctorSchedules.Queries.GetByServiceId;
using AppointmentSchedulingApp.Application.UseCases.Feedbacks.Queries.GetByDoctorId;
using AppointmentSchedulingApp.Application.UseCases.Services.Queries.GetAll;
using System.Text.Json.Serialization;

namespace AppointmentSchedulingApp.Application.UseCases.Doctors.Queries.GetById
{
    public class DoctorDetailQueryModel : DoctorQueryModel
    {
        public string? WorkExperience { get; set; }

        public string? Organization { get; set; }

        public string? Prize { get; set; }

        public string? ResearchProject { get; set; }

        public string? TrainingProcess { get; set; }

        //public IEnumerable<DoctorScheduleQueryModel> Schedules { get; set; }

        //public IEnumerable<ServiceQueryModel> Services { get; set; }

        //public IEnumerable<DoctorFeedbackQueryModel> Feedbacks { get; set; }

        //public IEnumerable<DoctorQueryModel> RelevantDoctors { get; set; }
    }
}
