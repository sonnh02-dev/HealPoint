
using AppointmentSchedulingApp.Domain.AggregatesModel.PatientAggregate;

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.Commons.Mappings
{
    public class PatientMapper : Profile
    {
        public PatientMapper()
        {
            //CreateMap<User, PatientDTO>()
            //    .IncludeBase<User, UserDTO>()
            //    .ForMember(dest => dest.Relationship, opt => opt.MapFrom(src => src.Patient.Relationship))
            //    .ForMember(dest => dest.MainCondition, opt => opt.MapFrom(src => src.Patient.MainCondition))
            //    .ForMember(dest => dest.Rank, opt => opt.MapFrom(src => src.Patient.Rank))
            //    .ReverseMap();

            //CreateMap<User, PatientDetailDTO>()
            //    .IncludeBase<User, PatientDTO>()                
            //    .ForMember(dest => dest.Guardian, opt => opt.MapFrom(src => src.Patient.Guardian))
            //    .ForMember(dest => dest.Dependents, opt => opt.MapFrom(src => src.PatientGuardians!=null? src.PatientGuardians.Select(pg=>pg.PatientNavigation):null))               
            //    .ForMember(dest => dest.MedicalRecords, opt => opt.MapFrom(src => src.Patient.Reservations.Where(r=>r.Status.Equals("Hoàn thành")).Select(r => r.MedicalRecord)))
            //    .ReverseMap();


            //CreateMap<Patient, GuardianOfPatientDTO>()
            //    .ForMember(dest => dest.GuardianId, opt => opt.MapFrom(src => src.GuardianId))
            //    .ReverseMap();

            //CreateMap<AddedPatientDTO,User>()
            //    .ReverseMap();

        }
    }
}
