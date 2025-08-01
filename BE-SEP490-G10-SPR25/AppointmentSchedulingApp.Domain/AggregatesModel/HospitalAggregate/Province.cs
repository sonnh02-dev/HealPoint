using AppointmentSchedulingApp.SharedKernel;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.HospitalAggregate
{
    public class Province:Entity
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<District> Districts { get; set; } = new List<District>();
    }
}