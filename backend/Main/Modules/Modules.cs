using FrituurApp.Main.Modules.Application;
using FrituurApp.Main.Modules.Messaging.DomainEvents;
using FrituurApp.Main.Modules.Persistence.EntityFramework;
using FrituurApp.Main.Modules.WebApi;

namespace FrituurApp.Main.Modules;

public static class ModuleExtensions
{
    public static IServiceCollection AddModules(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        return services
                .AddApplicationModule(configuration)
                .AddDomainEventModule(configuration)
                .AddEFCoreModule(configuration)
                .AddWebApiModule(configuration);
    }

    public static async Task<WebApplication> UseModules(this WebApplication app)
    {
        await app.UseEFCoreModule();
        
        app.UseWebApiModule();
        
        return app;
    }
}