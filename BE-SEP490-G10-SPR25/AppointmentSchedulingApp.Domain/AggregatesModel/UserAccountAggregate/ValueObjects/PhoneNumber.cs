using AppointmentSchedulingApp.Domain.AggregatesModel.UserAccountAggregate.Errors;
using AppointmentSchedulingApp.SharedKernel;
using System.Text.RegularExpressions;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.UserAccountAggregate.ValueObjects
{
    public sealed class PhoneNumber
    {
        private PhoneNumber(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<PhoneNumber> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result<PhoneNumber>.Failure("Số điện thoại không được trống hoặc chứa khoảng cách!", PhoneNumberErrors.Empty("Số điện thoại"));

            if (!IsValidFormat(value))
                return Result<PhoneNumber>.Failure("",PhoneNumberErrors.InvalidFormat("Số điện thoại",value, "Bắt đầu bằng 0 và dài 9-11 chữ số"));

            return Result<PhoneNumber>.Success(new PhoneNumber(value));
        }

        public static bool IsValidFormat(string value)
        {
            return Regex.IsMatch(value, @"^0\d{8,10}$");
        }
    }
}
