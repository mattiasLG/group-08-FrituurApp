namespace FrituurApp.Inventory.Domain.Events;

public interface IDomainEvent
{
    DateTime OccurredOnUtc { get; }
}