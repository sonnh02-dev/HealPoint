using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Specialties.Queries.GetAll
{
    public class SpecialtyQueryModel
    {
        [Key]
        public int SpecialtyId { get; set; }
        public string SpecialtyName { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int DoctorOfNumber { get; set; }
        public int ServiceOfNumber { get; set; }
    }



}
