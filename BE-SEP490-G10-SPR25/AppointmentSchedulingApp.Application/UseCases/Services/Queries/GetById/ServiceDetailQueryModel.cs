using AppointmentSchedulingApp.Application.UseCases.Doctors.Queries.GetByFilter;
using AppointmentSchedulingApp.Application.UseCases.Services.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Services.Queries.GetById
{
    public sealed class ServiceDetailQueryModel : ServiceQueryModel
    {
        public string SpecialtyName { get; set; }

        public IEnumerable<DoctorQueryModel> RelatedDoctors { get; set; }

        public List<string> RequiredDevices { get; set; } = new List<string>();
    }
}
