using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Queries.GetByFilter
{
    public  class MedicalRecordQueryModel
    {
        [Key]
        public string AppointmentId { get; set; }

        public string AppointmentDate { get; set; }

        public string? Symptoms { get; set; }

        public string? Diagnosis { get; set; }

        public string? TreatmentPlan { get; set; }

        public DateTime? FollowUpDate { get; set; }

        public string? Notes { get; set; }

       
    }
}
