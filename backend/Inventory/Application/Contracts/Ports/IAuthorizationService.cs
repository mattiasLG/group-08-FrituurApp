namespace FrituurApp.Inventory.Application.Contracts.Ports;

public interface IAuthorizationService
{
    void Authorize(string userRole, string permission);
}