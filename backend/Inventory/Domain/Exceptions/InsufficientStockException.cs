namespace FrituurApp.Inventory.Domain.Exceptions;

public sealed class InsufficientStockException : InventoryDomainException
{
    public Guid ItemId { get; }
    public int Requested { get; }
    public int Available { get; }

    public InsufficientStockException(Guid itemId, int requested, int available)
        : base($"Item {itemId}: requested {requested} but only {available} in stock.")
    {
        ItemId = itemId;
        Requested = requested;
        Available = available;
    }
}