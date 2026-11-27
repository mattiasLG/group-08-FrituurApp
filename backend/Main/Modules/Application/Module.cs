using FrituurApp.Inventory.Main.Modules.Application;

namespace FrituurApp.Main.Modules.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(
        this IServiceCollection services, 
        IConfiguration _configuration
    )
    {
        services.AddInventoryApplicationModule(_configuration);
        return services;
    }
}
