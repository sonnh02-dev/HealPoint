using AppointmentSchedulingApp.Application.UseCases.Doctors.Queries.GetByFilter;
using AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Queries.GetByFilter;
using System.Text.Json.Serialization;

namespace AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Queries.GetById
{
    public class MedicalRecordDetailQueryModel : MedicalRecordQueryModel
    {
        public int AppointmentId { get; set; }

        public string PatientName { get; set; }

        public int? PatientId { get; set; }

        public string PatientGender { get; set; }

        public string PatientDob { get; set; }
    }
}
