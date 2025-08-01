using AppointmentSchedulingApp.Domain.AggregatesModel.UserAccountAggregate.Errors;
using AppointmentSchedulingApp.SharedKernel;
using CleanArchitectrure.Domain.Commons;
using System.Text.RegularExpressions;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.UserAccountAggregate.ValueObjects;

public sealed record Email
{
    private Email(string value) => Value = value;

    public string Value { get; }

    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Email>.Failure("",EmailErrors.Empty("Email"));

        if (!IsValidFormat(value))
            return Result<Email>.Failure("", EmailErrors.InvalidFormat("Email", value, "example@domain.com"));

        return Result<Email>.Success(new Email(value));
    }

    public static bool IsValidFormat(string value)
    {
        return Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}
