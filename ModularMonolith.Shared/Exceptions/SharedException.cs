namespace ModularMonolith.Shared.Exceptions;

public class SharedException: Exception
{
    protected SharedException(string message) : base(message) { }
}