using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Feedbacks.Queries.GetByAppointmentId
{
    public class GetFeedbackByAppointmentIdHandler:IRequestHandler<GetFeedbackByAppointmentIdQuery,Result<AppointmentFeedbackQueryModel>>
    {

        public Task<Result<AppointmentFeedbackQueryModel>> Handle(GetFeedbackByAppointmentIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
