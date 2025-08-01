using AppointmentSchedulingApp.Application.UseCases.DoctorSchedules.Queries.GetByServiceId;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Appointments.Queries.GetAppointmentsByPatientIdAndFilter
{
    public class AppointmentQueryModel
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        //public PatientDTO Patient { get;set; }
        public DoctorScheduleQueryModel DoctorSchedule { get; set; }
        public string? Reason { get; set; }
        public string? PriorExaminationImg { get; set; }
        public string Status { get; set; }
        public string? CancellationReason { get; set; }

        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }


        public DateTime UpdatedDate { get; set; }

        public int UpdatedByUserId { get; set; }

        public string? PaymentStatus { get; set; } = null!;
        
        public string? PatientName { get; set; }



    }

}