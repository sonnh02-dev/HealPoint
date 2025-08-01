using AppointmentSchedulingApp.SharedKernel;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.UserAccountAggregate.ValueObjects;

public sealed record Name
{
    public Name(string? value)
    {
        Ensure.NotNullOrEmpty(value);

        Value = value;
    }

    public string Value { get; }
}
