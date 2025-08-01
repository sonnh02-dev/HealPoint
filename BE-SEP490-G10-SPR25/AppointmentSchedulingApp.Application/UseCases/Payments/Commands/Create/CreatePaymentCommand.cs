using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Payments.Commands.Create
{
    public class CreatePaymentCommand : IRequest<Result>
    {
        [Key]
        public int AppointmentId { get; set; }
        //public AddedReservationDTO Reservation { get; set; }
        public int PayerId { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}
