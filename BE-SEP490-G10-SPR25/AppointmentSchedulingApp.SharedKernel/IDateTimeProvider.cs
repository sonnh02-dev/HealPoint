namespace AppointmentSchedulingApp.SharedKernel;

public interface IDateTimeProvider
{
    DateTime GetUtcNow();
}
