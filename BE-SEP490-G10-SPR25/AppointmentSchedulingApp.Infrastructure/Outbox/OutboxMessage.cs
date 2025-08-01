namespace AppointmentSchedulingApp.Infrastructure.Outbox;

public sealed class OutboxMessage
{
    public int MessageId { get; set; }
    public string EventType { get; set; }
    public string Payload { get; set; }
    public DateTime? CreatedAt { get; set; }= DateTime.UtcNow;
    public DateTime? ProcessedAt { get; set; }
    public string? Error { get; set; }
}
