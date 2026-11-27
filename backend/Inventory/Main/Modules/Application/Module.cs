using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace FrituurApp.Inventory.Main.Modules.Application;

public static class ApplicationModule{
    public static IServiceCollection AddInventoryApplicationModule(
        this IServiceCollection services, 
        IConfiguration _configuration
    )
    {
        services.RegisterPolicies();
        return services;
    }

    private static IServiceCollection RegisterPolicies(this IServiceCollection services)
    {
        return services;
    }
}