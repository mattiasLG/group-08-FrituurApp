using FrituurApp.Inventory.Domain.Exceptions;

namespace FrituurApp.Inventory.Domain.ValueObjects;

public sealed record Money
{
    public decimal Amount { get; }

    private Money(decimal amount)
    {
        Amount = amount;
    }

    public static Money Create(decimal amount)
    {
        if (amount < 0)
            throw new InventoryDomainException("Price cannot be negative.");

        return new Money(decimal.Round(amount, 2, MidpointRounding.AwayFromZero));
    }

    public static Money Zero => new(0m);

    public override string ToString() => Amount.ToString("0.00");
}