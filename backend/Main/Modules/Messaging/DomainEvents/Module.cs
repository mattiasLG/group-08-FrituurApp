using FrituurApp.Inventory.Main.Modules.Messaging.DomainEvents;

namespace FrituurApp.Main.Modules.Messaging.DomainEvents;

public static class DomainEventModule
{
    public static IServiceCollection AddDomainEventModule(
        this IServiceCollection services,
        IConfiguration _configuration
    )
    {
        return services
                .AddInventoryDomainEventModule(_configuration);
    }
}