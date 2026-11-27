using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace FrituurApp.Inventory.Main.Modules.Messaging.DomainEvents;

public static class DomainEventModule
{
    public static IServiceCollection AddInventoryDomainEventModule(
        this IServiceCollection services,
        IConfiguration _configuration
    )
    {
        return services;
    }
}