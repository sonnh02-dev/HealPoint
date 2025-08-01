using Amazon.Runtime.Internal;
using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Posts.Commands.Update
{
    public class UpdatePostCommand:IRequest<Result>
    {
    }
}
