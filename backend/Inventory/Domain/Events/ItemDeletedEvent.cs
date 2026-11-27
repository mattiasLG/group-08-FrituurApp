namespace FrituurApp.Inventory.Domain.Events;

public sealed record ItemDeletedEvent(Guid ItemId) : IDomainEvent
{
    public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;
}