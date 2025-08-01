using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace AppointmentSchedulingApp.Application.Abstractions.Authentication
{
    public interface ITokenService
    {
        string GenerateAccessToken(int userId, string email, IEnumerable<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
        bool ValidateToken(string token);
    }
}
