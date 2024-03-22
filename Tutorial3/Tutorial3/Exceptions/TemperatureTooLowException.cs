namespace Tutorial3.Interfaces;

public class TemperatureTooLowException : Exception
{
    public TemperatureTooLowException()
    {
    }
    public TemperatureTooLowException(string? message) : base(message)
    {
    }
    public TemperatureTooLowException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}