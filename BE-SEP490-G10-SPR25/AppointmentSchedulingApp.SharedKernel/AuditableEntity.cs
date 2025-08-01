using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.SharedKernel
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime? CreatedAt { get; set; }
        public int? CreatorId { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public int? ModifierId { get; set; }

        public DateTime? DeletedAt { get; set; }       
        public bool IsDeleted { get; set; } = false;


        public int Version { get; set; } 
    }

}
