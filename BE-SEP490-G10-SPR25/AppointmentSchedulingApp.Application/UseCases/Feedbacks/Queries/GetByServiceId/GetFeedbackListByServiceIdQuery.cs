using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Feedbacks.Queries.GetByServiceId
{
    public class GetFeedbackListByServiceIdQuery:IRequest<Result<ServiceFeedbackQueryModel>>
    {
    }
}
