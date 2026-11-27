namespace FrituurApp.Main.Modules.Persistence.EntityFramework;

public static class PersistenceModule
{
    public static IServiceCollection AddEFCoreModule(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services;
    }

    public static async Task<WebApplication> UseEFCoreModule(this WebApplication app)
    {
        return app; 
    }
}
