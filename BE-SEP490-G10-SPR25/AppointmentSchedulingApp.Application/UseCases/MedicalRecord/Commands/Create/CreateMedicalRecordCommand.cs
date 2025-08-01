using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Commands.Create
{
    public class CreateMedicalRecordCommand: IRequest<Result>
    {
        [Required]
        public int ReservationId { get; set; }

        public string? Symptoms { get; set; }

        public string? Diagnosis { get; set; }

        public string? TreatmentPlan { get; set; }

        public DateTime? FollowUpDate { get; set; }

        public string? Notes { get; set; }
    }
}
