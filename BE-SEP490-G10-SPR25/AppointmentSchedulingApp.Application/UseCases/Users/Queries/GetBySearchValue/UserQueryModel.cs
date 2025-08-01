using System.ComponentModel.DataAnnotations;

namespace AppointmentSchedulingApp.Application.UseCases.Users.Queries.GetBySearchValue
{
    public class UserQueryModel
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; } = null!;

        public string? Email { get; set; }

        public string Phone { get; set; } = null!;

        public long CitizenId { get; set; }

        public string Gender { get; set; }=null!;

        public DateTime? Dob { get; set; } 

        public string Address { get; set; } = null!;

        public string? AvatarUrl { get; set; }

        public bool IsVerify { get; set; }

        public bool IsActive { get; set; }

        public string[] RoleNames { get; set; } = new string[0];

    }
}
