using FrituurApp.Inventory.Domain.Shared;

namespace FrituurApp.Inventory.Application.Contracts.Ports;

public interface IUnitOfWork
{
    Task Do();
    Task Save<TRepository>(IAggregateRoot aggregateRoot) where TRepository : IRepository;
    TRepository Repo<TRepository>() where TRepository : IRepository;
}
