namespace FrituurApp.Main.Modules.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(
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
