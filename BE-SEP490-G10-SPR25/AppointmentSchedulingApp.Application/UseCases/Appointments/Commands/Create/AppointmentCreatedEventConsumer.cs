
using AppointmentSchedulingApp.Domain.AggregatesModel.AppointmentAggregate;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Application.Users.GetByEmail;
public class AppointmentCreatedEventConsumer : IConsumer<AppointmentCreatedEvent>
{
    private readonly ILogger<AppointmentCreatedEventConsumer> _logger;

    public AppointmentCreatedEventConsumer(ILogger<AppointmentCreatedEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<AppointmentCreatedEvent> context)
    {
        throw new NotImplementedException();
    }
}
