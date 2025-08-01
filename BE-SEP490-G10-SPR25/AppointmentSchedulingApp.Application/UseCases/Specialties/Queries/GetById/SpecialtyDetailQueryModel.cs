using AppointmentSchedulingApp.Application.UseCases.Doctors.Queries.GetByFilter;
using AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Queries.GetByFilter;
using AppointmentSchedulingApp.Application.UseCases.Services.Queries.GetAll;
using AppointmentSchedulingApp.Application.UseCases.Specialties.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Specialties.Queries.GetById
{
    public class SpecialtyDetailQueryModel : SpecialtyQueryModel
    {
        public string? SpecialtyDescription { get; set; }

        public IEnumerable<string> Devices { get; set; } = new List<string>();

        public IEnumerable<ServiceQueryModel> Services { get; set; } = new List<ServiceQueryModel>();

        public IEnumerable<DoctorQueryModel> Doctors { get; set; } = new List<DoctorQueryModel>();
    }
}
