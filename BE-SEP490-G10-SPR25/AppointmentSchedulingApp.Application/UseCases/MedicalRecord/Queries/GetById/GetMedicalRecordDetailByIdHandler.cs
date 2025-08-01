using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Queries.GetById
{
    internal class GetMedicalRecordDetailByIdHandler : IRequestHandler<GetMedicalRecordDetailByIdQuery, Result<MedicalRecordDetailQueryModel>>
    {
        public Task<Result<MedicalRecordDetailQueryModel>> Handle(GetMedicalRecordDetailByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
