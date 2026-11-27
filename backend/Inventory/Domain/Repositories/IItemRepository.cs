using FrituurApp.Inventory.Domain.Entities;

namespace FrituurApp.Inventory.Domain.Repositories;

/// <summary>
/// Port implemented in the Infrastructure layer (EF Core).
/// Methods persist immediately; there is no separate unit of work.
/// </summary>
public interface IItemRepository
{
    Task<Item?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Item>> GetAllAsync(bool includeArchived = false, CancellationToken cancellationToken = default);

    Task AddAsync(Item item, CancellationToken cancellationToken = default);

    Task UpdateAsync(Item item, CancellationToken cancellationToken = default);
}