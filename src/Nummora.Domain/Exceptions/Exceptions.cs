namespace Nummora.Domain.Exceptions;

public static class Exceptions
{
    public class IdNotFoundException(string message) : KeyNotFoundException(message);

    public class UserNotFoundException(string message) : Exception(message);
    
    public class InternalServerErrorException : Exception
    {
        public InternalServerErrorException(string message) : base(message){}
        public InternalServerErrorException(Exception inner) : base(inner.Message){}
    }
}