using AppointmentSchedulingApp.SharedKernel;

namespace AppointmentSchedulingApp.Domain.AggregatesModel.UserAccountAggregate.Events;

public sealed record UserAccountCreatedEvent(Guid UserId) : IDomainEvent;
