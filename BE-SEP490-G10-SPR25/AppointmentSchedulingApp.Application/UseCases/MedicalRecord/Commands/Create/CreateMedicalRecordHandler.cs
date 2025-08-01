using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Commands.Create
{
    public class CreateMedicalRecordHandler : IRequestHandler<CreateMedicalRecordCommand, Result>
    {
        public Task<Result> Handle(CreateMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
