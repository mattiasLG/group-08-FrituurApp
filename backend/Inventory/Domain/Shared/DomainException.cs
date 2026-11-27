namespace FrituurApp.Inventory.Domain.Shared;

public static class BaseDomainAsserts
{
    public static void EnsureNotEmpty<T>(
        string value
    ) where T : DomainException, new()
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new T();
    }
    public static void EnsureNotEmpty<T>(
        object value
    )where T : DomainException, new()
    {
        if (value == null)
            throw new T();
    }

    public static void EnsureNotEmpty(
        object value,
        string _object
    )
    {
        if (value == null)
            throw new ObjectIsNull(_object);
    }

    public static void EnsureNotNegative<T>(
        int value
    )where T : DomainException, new()
    {
        if (value < 0)
            throw new T();
    }

    public static void EnsureListNotEmpty<T, L>(
        List<L> list
    )where T : DomainException, new()
    {
        if (list == null || list.Count==0)
            throw new T();
    }
}

public sealed class ObjectIsNull : DomainException
{
    public ObjectIsNull(string _object):base($"{_object} is null."){}
}


public class DomainException : Exception
{
    public DomainException()
    {
    }

    public DomainException(string message)
        : base(message)
    {
    }

    public DomainException(string message, Exception inner)
        : base(message, inner)
    {
    }
}