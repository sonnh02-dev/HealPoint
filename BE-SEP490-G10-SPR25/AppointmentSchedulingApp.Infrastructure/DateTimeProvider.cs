using AppointmentSchedulingApp.SharedKernel;

namespace AppointmentSchedulingApp.Infrastructure;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;

    public DateTime GetUtcNow()
    {
        throw new NotImplementedException();
    }
}
