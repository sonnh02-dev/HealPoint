using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Queries.GetById
{
    public class GetMedicalRecordDetailByIdQuery:IRequest<Result<MedicalRecordDetailQueryModel>>
    {
    }
}
