using Microsoft.EntityFrameworkCore;
using FrituurApp.Inventory.Domain.Shared.DomainEvents;
using FrituurApp.Inventory.Infrastructure.Persistence.EntityFramework.Configuration.Converters;

namespace FrituurApp.Inventory.Infrastructure.Persistence.EntityFramework.Configuration;

public abstract class DomainDbContext : DbContext
{    private readonly Queue<IDomainEvent> _queuedDomainEvents = new();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        EntityIdConverter.AddConventions(configurationBuilder);
        SinglePropertyValueObjectConverter.AddConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public void QueueDomainEvent(IEnumerable<IDomainEvent> domainEvents)
    {
        foreach (var domainEvent in domainEvents)
            _queuedDomainEvents.Enqueue(domainEvent);
    }

    public IReadOnlyCollection<IDomainEvent> GetQueuedDomainEvents()
    {
        return _queuedDomainEvents.ToList().AsReadOnly();
    }

    public void ClearQueuedDomainEvents()
    {
        _queuedDomainEvents.Clear();
    }
}
