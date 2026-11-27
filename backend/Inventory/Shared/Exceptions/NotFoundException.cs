namespace FrituurApp.Inventory.Shared.Exceptions;

public sealed class NotFoundException(string message) : Exception(message)
{
}