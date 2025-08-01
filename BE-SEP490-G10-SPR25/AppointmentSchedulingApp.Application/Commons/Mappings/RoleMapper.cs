
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.Commons.Mappings
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            //CreateMap<Role, RoleDTO>()
            //    .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            //    .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))
            //    .ReverseMap();
        }
    }
}
