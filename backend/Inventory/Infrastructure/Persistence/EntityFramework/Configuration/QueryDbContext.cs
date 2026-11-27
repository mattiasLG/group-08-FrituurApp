using Microsoft.EntityFrameworkCore;

namespace FrituurApp.Inventory.Infrastructure.Persistence.EntityFramework.Configuration;

public abstract class QueryDbContext : DbContext
{
    protected QueryDbContext()
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}