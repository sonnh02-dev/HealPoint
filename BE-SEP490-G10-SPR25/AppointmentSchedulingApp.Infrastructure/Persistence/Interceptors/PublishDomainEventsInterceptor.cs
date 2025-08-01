using AppointmentSchedulingApp.Application.Abstractions.EventBus;
using AppointmentSchedulingApp.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AppointmentSchedulingApp.Infrastructure.Persistence.Interceptors;

internal sealed class PublishDomainEventsInterceptor : SaveChangesInterceptor
{
    private readonly IEventBus eventBus;

    public PublishDomainEventsInterceptor(IEventBus eventBus)
    {
        this.eventBus = eventBus;
    }

    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default)
    {
        result = await base.SavedChangesAsync(eventData, result, cancellationToken);
        if (eventData.Context is not null)
        {
            await PublishDomainEventsAsync(eventData.Context, cancellationToken);


        }
        return result;
    }

    private async Task PublishDomainEventsAsync(DbContext context, CancellationToken cancellationToken)
    {
        var domainEvents = context
            .ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                List<IDomainEvent> domainEvents = entity.DomainEvents;

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await eventBus.PublishAsync((dynamic)domainEvent, cancellationToken);
        }
    }
}
