namespace Microservice.Infrastructure.Exceptions;

public class NullReferanceException : Exception
{
    public NullReferanceException() : base() { }
    public NullReferanceException(string message) : base(message) { }
}
