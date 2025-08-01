using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.MedicalRecords.Commands.Update
{
    public class UpdateMedicalRecordHandler : IRequestHandler<UpdateMedicalRecordCommand, Result>
    {
        public Task<Result> Handle(UpdateMedicalRecordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
