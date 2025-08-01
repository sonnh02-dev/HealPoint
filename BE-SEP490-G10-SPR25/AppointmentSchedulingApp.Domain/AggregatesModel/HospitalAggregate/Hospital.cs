using AppointmentSchedulingApp.Domain.AggregatesModel.RoomAggregate;
using AppointmentSchedulingApp.SharedKernel;
using System;
using System.Collections.Generic;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.HospitalAggregate
{
    public class Hospital : Entity
    {
        public int HospitalId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

        public int WardId { get; set; }
        public Ward Ward { get; set; }

        // Vị trí bản đồ
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        //Liên hê
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Description { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
