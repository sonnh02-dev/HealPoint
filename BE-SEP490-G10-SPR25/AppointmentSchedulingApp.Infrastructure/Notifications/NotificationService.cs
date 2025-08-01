using AppointmentSchedulingApp.Application.Abstractions.Notifications;

namespace AppointmentSchedulingApp.Infrastructure.Notifications;

internal sealed class NotificationService : INotificationService
{
    public Task SendAsync(Guid userId, string message, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
