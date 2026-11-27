namespace FrituurApp.Inventory.Domain.Shared.DomainEvents;

public class BaseDomainEvent(
    string eventName,
    string aggregateName,
    string boundedContext = nameof(Inventory),
    string companyName = nameof(FrituurApp)
) : IDomainEvent
{
    public string FQDN { get; private init; } = $"{companyName}.{boundedContext}.{aggregateName}.{eventName}";
    public DateTime OccurredOn { get; private init; } = DateTime.UtcNow;
}
