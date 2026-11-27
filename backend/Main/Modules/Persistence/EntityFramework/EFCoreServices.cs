using Microsoft.EntityFrameworkCore;


namespace FrituurApp.Main.Modules.Persistence.EntityFramework;

public static class EFCoreServices
{
    public static IServiceCollection AddEFCoreServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        return services;
    }
}