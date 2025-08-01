using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Queries.GetByFilter
{
    internal class GetMedicalRecordsByFilterHandler : IRequestHandler<GetMedicalRecordsByFilterQuery, Result<IEnumerable<MedicalRecordQueryModel>>>
    {
        public Task<Result<IEnumerable<MedicalRecordQueryModel>>> Handle(GetMedicalRecordsByFilterQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
