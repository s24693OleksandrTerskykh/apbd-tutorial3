namespace Tutorial3.Exceptions;

public class TooManyContainersException : Exception
{
    public TooManyContainersException()
    {
    }
    public TooManyContainersException(string? message) : base(message)
    {
    }
   
}