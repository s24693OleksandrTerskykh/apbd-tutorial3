namespace Tutorial3.Exceptions;

public class ContainerTooHeavyException : Exception
{
    public ContainerTooHeavyException()
    {
    }
    public ContainerTooHeavyException(string? message) : base(message)
    {
    }
}