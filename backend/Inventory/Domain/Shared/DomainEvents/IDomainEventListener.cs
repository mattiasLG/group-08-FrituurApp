namespace FrituurApp.Inventory.Domain.Shared.DomainEvents;

public interface IDomainEventListener
{
    Task Listen(IDomainEvent domainEvent);
}
