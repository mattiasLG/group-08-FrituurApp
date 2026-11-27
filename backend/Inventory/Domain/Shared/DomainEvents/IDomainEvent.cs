namespace FrituurApp.Inventory.Domain.Shared.DomainEvents;

public interface IDomainEvent
{
    string FQDN { get; }
    DateTime OccurredOn { get; }
}
