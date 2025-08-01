using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppointmentSchedulingApp.Domain.AggregatesModel.RoomAggregate;
using AutoMapper;

namespace AppointmentSchedulingApp.Application.Commons.Mappings
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            //CreateMap<Room, RoomDTO>()
            //    .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.RoomName))
            //    .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType))
            //    .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
            //    .ReverseMap();
        }
    }
}
