using AppointmentSchedulingApp.SharedKernel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Authentication
{
    public class UserAccount:IdentityUser<int>
    {
        public DateTime? CreatedAt { get; set; }
        public int? CreatorId { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public int? ModifierId { get; set; }

        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}
