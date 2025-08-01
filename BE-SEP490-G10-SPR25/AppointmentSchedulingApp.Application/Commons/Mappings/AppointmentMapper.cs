using AppointmentSchedulingApp.Application.UseCases.Appointments.Queries.GetAppointmentsByPatientIdAndFilter;
using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.Commons.Mappings
{
    public class AppointmentMapper:Profile

    {
        public AppointmentMapper()
        {
            
            // CreateMap<Appointment,AppointmentQueryModel>()
            
            // .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient.PatientNavigation))
            // .ForMember(dest => dest.DoctorSchedule, opt => opt.MapFrom(src => src.DoctorSchedule))          
            // .ForMember(dest => dest.PaymentStatus, opt => opt.MapFrom(src => src.Payment.PaymentStatus))          
            // .ReverseMap();   


            // CreateMap<Appointment, ReservationStatusDTO>()
            // .ForMember(dest => dest.CancellationReason, opt => opt.MapFrom(src => src.CancellationReason))
            // .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            // .ReverseMap();

            //CreateMap<AddedReservationDTO, Appointment>().ReverseMap();



        }
    }
}