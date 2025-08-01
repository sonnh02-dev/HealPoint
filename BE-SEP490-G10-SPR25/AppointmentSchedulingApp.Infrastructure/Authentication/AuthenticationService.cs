using AppointmentSchedulingApp.Domain.AggregatesModel.UserProfileAggregate;
using AppointmentSchedulingApp.SharedKernel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AppointmentSchedulingApp.Application.Abstractions.Authentication;
using AppointmentSchedulingApp.Domain.AggregatesModel.UserAccountAggregate.ValueObjects;

namespace AppointmentSchedulingApp.Infrastructure.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<UserProfile> _userManager;
        private readonly SignInManager<UserProfile> _signInManager;

        public AuthenticationService(UserManager<UserProfile> userManager, SignInManager<UserProfile> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //public async Task<Result<UserAccount>> CheckUserExistsAsync(string identifier)
        //{
           
        //    if (Email.IsValidFormat(identifier))
        //    {
        //        var userByEmail = await _userManager.FindByEmailAsync(identifier);
        //        return userByEmail!=null ?  Result.Success<UserProfile>(userByEmail): Result.Failure<UserProfile>(UserErrors.NotFoundByEmail(identifier));
        //    }
        //     if (PhoneNumber.IsValidFormat(identifier))
        //    {
        //        var userByPhone = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber.Equals(identifier));
        //        return userByPhone != null ? Result.Success<UserProfile>(userByPhone) : Result.Failure<UserProfile>(UserErrors.NotFoundByPhoneNumber(identifier));

        //    }


        //    return  string.IsNullOrWhiteSpace(identifier)? Result.Failure<UserProfile>(BaseError.)
        //}


        //public async Task<bool> IsLockedOutAsync(UserProfile user)
        //{
        //    return await _userManager.IsLockedOutAsync(user);
        //}

        //public async Task<bool> ValidatePasswordAsync(UserProfile user, string password)
        //{
        //    var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        //    return result.Succeeded;
        //}

        //public async Task<BaseResponse<string>> LoginAsync(string phoneNumber, string email, string userName, string password)
        //{
        //    var user = await CheckUserExistsAsync(phoneNumber, email, userName);
        //    if (user == null)
        //        return BaseResponse<string>.Fail("User not found");

        //    if (await IsLockedOutAsync(user))
        //        return BaseResponse<string>.Fail("Account is locked out");

        //    if (!await ValidatePasswordAsync(user, password))
        //        return BaseResponse<string>.Fail("Invalid credentials");

        //    var token = await GenerateFakeToken(user);

        //    return BaseResponse<string>.Success(token);
        //}

        //public Task<string> GenerateFakeToken(UserProfile user)
        //{
        //    // Sau này bạn có thể đổi sang JWT ở đây
        //    return Task.FromResult($"fake-token-for-{user.Id}");
        //}
    }


}
