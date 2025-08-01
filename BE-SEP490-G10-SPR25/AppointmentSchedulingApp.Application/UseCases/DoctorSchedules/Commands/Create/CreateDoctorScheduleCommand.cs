using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.DoctorSchedules.Commands.Create
{
    public class CreateDoctorCommand: IRequest<Result>
    {
        public int DoctorId { get; set; }

        public int ServiceId { get; set; }

        public string DayOfWeek { get; set; } = null!;

        public int RoomId { get; set; }

        public int SlotId { get; set; }
    }
}
