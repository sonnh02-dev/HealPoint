using AppointmentSchedulingApp.SharedKernel;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.HospitalAggregate
{
    public class District:Entity
    {
        public int DistrictId { get; set; }
        public string Name { get; set; } = null!;
        public int ProvinceId { get; set; }
        public Province Province { get; set; } = null!;
        public ICollection<Ward> Wards { get; set; } = new List<Ward>();
    }
}