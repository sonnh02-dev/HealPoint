using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppointmentSchedulingApp.Domain.AggregatesModel.SlotAggregate;
using AutoMapper;

namespace AppointmentSchedulingApp.Application.Commons.Mappings
{
    public class SlotMapper : Profile
    {
        public SlotMapper()
        {
            //CreateMap<Slot, SlotDTO>()
            //    .ForMember(dest => dest.SlotStartTime, opt => opt.MapFrom(src => src.SlotStartTime))
            //    .ForMember(dest => dest.SlotEndTime, opt => opt.MapFrom(src => src.SlotEndTime))
            //    .ReverseMap();
        }
    }
}
