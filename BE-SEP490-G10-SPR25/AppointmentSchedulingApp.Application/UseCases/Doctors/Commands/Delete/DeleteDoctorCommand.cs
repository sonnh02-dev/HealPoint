using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Doctors.Commands.Delete
{
    public class DeleteDoctorCommand : IRequest<Result>
    {

        public int DoctorId { get; set; }

        
    }
}
