namespace FrituurApp.Inventory.Domain.Events;

public sealed record LowStockEvent(Guid ItemId, int StockQuantity, int Threshold) : IDomainEvent
{
    public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;
}