using AppointmentSchedulingApp.Application.UseCases.Doctors.Queries.GetById;
using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Doctors.Commands.Update
{
    public class UpdatePaymentCommand : IRequest<Result>
    {
        public DoctorDetailQueryModel UpdatedDoctor;
    }
}
