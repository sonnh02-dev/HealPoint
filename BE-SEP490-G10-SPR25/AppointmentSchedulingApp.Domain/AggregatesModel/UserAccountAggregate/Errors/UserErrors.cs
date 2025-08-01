using AppointmentSchedulingApp.SharedKernel;
using CleanArchitectrure.Domain.Commons;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.UserAccountAggregate.Errors;

public class UserErrors : BaseErrors
{
    public static Error NotFoundByEmail(string email) => Error.NotFound(
        "UserAccount.NotFoundByEmail", $"Không tìm thấy người dùng với email: '{email}'!");

    public static Error NotFoundByPhoneNumber(string phoneNumber) => Error.NotFound(
        "UserAccount.NotFoundByPhoneNumber", $"Không tìm thấy người dùng với số điện thoại: '{phoneNumber}'!");

    public static readonly Error EmailNotUnique = Error.Conflict(
        "UserAccount.EmailNotUnique", "Email đã tồn tại trong hệ thống!");

    public static readonly Error PhoneNumberNotUnique = Error.Conflict(
        "UserAccount.PhoneNumberNotUnique", "Số điện thoại đã tồn tại trong hệ thống!");

    public static readonly Error UsernameNotUnique = Error.Conflict(
        "UserAccount.UserNameNotUnique", "Tên người dùng đã tồn tại trong hệ thống!");

    public static Error InvalidPasswordFormat(string formatHint) => Error.Validation(
        "UserAccount.InvalidPasswordFormat", $"Mật khẩu không đúng định dạng. Gợi ý: {formatHint}");

    public static readonly Error InvalidCredentials = Error.Failure(
        "UserAccount.InvalidCredentials", "Thông tin đăng nhập không chính xác!");

    public static readonly Error AccountLocked = Error.Failure(
        "UserAccount.AccountLocked", "Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị viên!");
}
