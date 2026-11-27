namespace FrituurApp.Inventory.Domain.Events;

public sealed record ItemCreatedEvent(Guid ItemId) : IDomainEvent
{
    public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;
}