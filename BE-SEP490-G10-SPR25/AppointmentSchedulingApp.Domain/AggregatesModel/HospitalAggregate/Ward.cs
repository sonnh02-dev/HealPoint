using AppointmentSchedulingApp.SharedKernel;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.HospitalAggregate
{
    public class Ward:Entity
    {
        public int WardId { get; set; }
        public string Name { get; set; } = null!;
        public int DistrictId { get; set; }
        public District District { get; set; } = null!;
    }
}