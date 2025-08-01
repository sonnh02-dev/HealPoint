using AppointmentSchedulingApp.Domain.AggregatesModel.DoctorAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.PostAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.ReceptionistAggregate;
using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using AppointmentSchedulingApp.SharedKernel;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate
{
    public sealed class UserProfile : Entity
    {
        public long? CitizenId { get;  set; }
        public string? FullName { get;  set; } = string.Empty;
        public string? Gender { get;  set; } = string.Empty;
        public DateOnly? Dob { get;  set; }
        public string? Address { get;  set; } = string.Empty;
        public string? Nationality { get;  set; } = string.Empty;
        public string? Ethnicity { get;  set; }
        public string? AvatarUrl { get;  set; } = string.Empty;
        public bool IsVerify { get;  set; }
        public bool IsActive { get;  set; }

        public Patient? Patient { get;  set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public Doctor? Doctor { get;  set; }
        public Receptionist? Receptionist { get;  set; }
        public ICollection<Appointment> CreatedAppointments { get;  set; }
        public ICollection<Appointment> ModifiedAppointments { get; set; }
        public UserProfile() { }

    }
}
