using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Feedbacks.Queries.GetByDoctorId
{
    public class GetFeedbackListByDoctorIdHandler : IRequestHandler<GetFeedbackListByDoctorIdQuery, Result<DoctorFeedbackQueryModel>>
    {
        public Task<Result<DoctorFeedbackQueryModel>> Handle(GetFeedbackListByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
