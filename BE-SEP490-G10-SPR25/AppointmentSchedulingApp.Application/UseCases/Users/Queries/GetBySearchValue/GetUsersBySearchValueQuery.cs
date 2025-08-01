
using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Application.UseCases.Users.Queries.GetBySearchValue
{
    public class GetUsersBySearchValueQuery: IRequest<Result<UserQueryModel>>
    {
        public string SearchValue { get; set; } = null!;
    
        
    }
}
