namespace FrituurApp.Inventory.Domain.Events;

public sealed record ItemUpdatedEvent(Guid ItemId) : IDomainEvent
{
    public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;
}