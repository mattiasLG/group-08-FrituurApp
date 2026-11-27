using Microsoft.Extensions.Logging;
using FrituurApp.Inventory.Infrastructure.Persistence.EntityFramework.Configuration;
using FrituurApp.Inventory.Domain.Shared;

namespace FrituurApp.Inventory.Infrastructure.Persistence.EntityFramework.Seeders;

public class DomainDbSeeder(DomainDbContext context, ILogger<DomainDbSeeder> _logger)
{
    public async Task Seed()
    {
        _logger.LogInformation("Seeding inventory data...");
        await context.SaveChangesAsync();
    }
}
