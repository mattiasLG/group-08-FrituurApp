using FrituurApp.Inventory.Domain.Enums;
using FrituurApp.Inventory.Domain.Events;
using FrituurApp.Inventory.Domain.Exceptions;
using FrituurApp.Inventory.Domain.ValueObjects;

namespace FrituurApp.Inventory.Domain.Entities;

public sealed class Item : AggregateRoot
{
    public const int DefaultLowStockThreshold = 5;

    private readonly HashSet<Allergen> _allergens = new();

    public Guid Id { get; private set; }
    public LocalizedText Name { get; private set; }
    public LocalizedText Description { get; private set; }
    public LocalizedText Ingredients { get; private set; }
    public Money Price { get; private set; }
    public int StockQuantity { get; private set; }
    public int LowStockThreshold { get; private set; }

    /// <summary>Manual on/off switch set by the admin.</summary>
    public bool IsAvailable { get; private set; }

    /// <summary>Soft delete: keeps historical orders intact.</summary>
    public bool IsArchived { get; private set; }

    public IReadOnlySet<Allergen> Allergens => _allergens;

    public bool IsLowStock => StockQuantity <= LowStockThreshold;

    /// <summary>What customers can actually order right now.</summary>
    public bool IsOrderable => !IsArchived && IsAvailable && StockQuantity > 0;

    // Required by EF Core (Infrastructure layer).
    private Item()
    {
        Name = null!;
        Description = null!;
        Ingredients = null!;
        Price = null!;
    }

    private Item(
        Guid id,
        LocalizedText name,
        LocalizedText description,
        LocalizedText ingredients,
        Money price,
        int stockQuantity,
        int lowStockThreshold,
        IEnumerable<Allergen> allergens)
    {
        Id = id;
        Name = name;
        Description = description;
        Ingredients = ingredients;
        Price = price;
        StockQuantity = stockQuantity;
        LowStockThreshold = lowStockThreshold;
        IsAvailable = true;
        _allergens = new HashSet<Allergen>(allergens);
    }

    public static Item Create(
        LocalizedText name,
        LocalizedText description,
        LocalizedText ingredients,
        Money price,
        int stockQuantity,
        IEnumerable<Allergen> allergens,
        int lowStockThreshold = DefaultLowStockThreshold)
    {
        if (stockQuantity < 0)
            throw new InventoryDomainException("Stock cannot be negative.");
        if (lowStockThreshold < 0)
            throw new InventoryDomainException("Low stock threshold cannot be negative.");

        var item = new Item(
            Guid.NewGuid(), name, description, ingredients, price,
            stockQuantity, lowStockThreshold, allergens);

        item.Raise(new ItemCreatedEvent(item.Id));
        return item;
    }

    public void Update(
        LocalizedText name,
        LocalizedText description,
        LocalizedText ingredients,
        Money price,
        IEnumerable<Allergen> allergens)
    {
        EnsureNotArchived();

        Name = name;
        Description = description;
        Ingredients = ingredients;
        Price = price;

        _allergens.Clear();
        foreach (var allergen in allergens)
            _allergens.Add(allergen);

        Raise(new ItemUpdatedEvent(Id));
    }

    public void ChangePrice(Money price)
    {
        EnsureNotArchived();

        Price = price;
        Raise(new ItemUpdatedEvent(Id));
    }

    public void SetAvailability(bool isAvailable)
    {
        EnsureNotArchived();

        if (IsAvailable == isAvailable)
            return;

        IsAvailable = isAvailable;
        Raise(new ItemUpdatedEvent(Id));
    }

    public void SetStock(int quantity)
    {
        EnsureNotArchived();

        if (quantity < 0)
            throw new InventoryDomainException("Stock cannot be negative.");

        ApplyStock(quantity);
    }

    public void IncreaseStock(int amount)
    {
        EnsureNotArchived();

        if (amount <= 0)
            throw new InventoryDomainException("Amount must be greater than zero.");

        ApplyStock(StockQuantity + amount);
    }

    public void DecreaseStock(int amount)
    {
        EnsureNotArchived();

        if (amount <= 0)
            throw new InventoryDomainException("Amount must be greater than zero.");
        if (amount > StockQuantity)
            throw new InsufficientStockException(Id, amount, StockQuantity);

        ApplyStock(StockQuantity - amount);
    }

    public void ChangeLowStockThreshold(int threshold)
    {
        EnsureNotArchived();

        if (threshold < 0)
            throw new InventoryDomainException("Low stock threshold cannot be negative.");

        LowStockThreshold = threshold;
    }

    public void Archive()
    {
        if (IsArchived)
            return;

        IsArchived = true;
        IsAvailable = false;
        Raise(new ItemDeletedEvent(Id));
    }

    private void ApplyStock(int newQuantity)
    {
        var wasLow = IsLowStock;
        StockQuantity = newQuantity;

        Raise(new ItemUpdatedEvent(Id));

        // Only warn when we cross the threshold, not on every change below it.
        if (!wasLow && IsLowStock)
            Raise(new LowStockEvent(Id, StockQuantity, LowStockThreshold));
    }

    private void EnsureNotArchived()
    {
        if (IsArchived)
            throw new InventoryDomainException("Archived items cannot be modified.");
    }
}