using AppointmentSchedulingApp.Application.Abstractions.EventBus;
using AppointmentSchedulingApp.Infrastructure.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentSchedulingApp.Infrastructure.Outbox
{
    public sealed class OutboxMessagePublisher : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEventBus _eventBus;
        private readonly ILogger<OutboxMessagePublisher> _logger;

        private static readonly JsonSerializerSettings SerializerSettings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public OutboxMessagePublisher(
            IServiceProvider serviceProvider,
            IEventBus eventBus,
            ILogger<OutboxMessagePublisher> logger)
        {
            _serviceProvider = serviceProvider;
            _eventBus = eventBus;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("OutboxMessagePublisher started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationCommandDbContext>();

                    var pendingMessages = dbContext.OutboxMessages
                        .Where(x => x.ProcessedAt == null)
                        .OrderBy(x => x.CreatedAt)
                        .Take(20)
                        .ToList();

                    foreach (var message in pendingMessages)
                    {
                        object? domainEvent = null;

                        try
                        {
                            domainEvent = JsonConvert.DeserializeObject(message.Payload, SerializerSettings);

                            if (domainEvent == null)
                            {
                                _logger.LogWarning("Failed to deserialize message {MessageId}", message.MessageId);
                                continue;
                            }

                            await Policy
                                .Handle<Exception>()
                                .WaitAndRetryAsync(
                                    retryCount: 3,
                                    sleepDurationProvider: attempt => TimeSpan.FromSeconds(2),
                                    onRetry: (ex, delay, retryCount, ctx) =>
                                    {
                                        _logger.LogWarning(ex, "Retry {RetryCount} publishing message {MessageId}", retryCount, message.Id);
                                    })
                                .ExecuteAsync(() =>
                                    _eventBus.PublishAsync((dynamic)domainEvent!, stoppingToken)
                                );

                            message.ProcessedAt = DateTime.UtcNow;
                            _logger.LogInformation("Published and marked message {MessageId} as processed.", message.MessageId);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Failed to process OutboxMessage {MessageId}", message.MessageId);
                            // do not mark ProcessedAt → will retry later
                        }
                    }

                    await dbContext.SaveChangesAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error in OutboxMessagePublisher loop.");
                }

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            _logger.LogInformation("OutboxMessagePublisher stopped.");
        }
    }
}
