using FrituurApp.Inventory.Domain.Shared.DomainEvents;

namespace FrituurApp.Inventory.Application.Contracts.Ports;

public interface IPolicy<in TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    Task Execute (TDomainEvent domainEvent);
}