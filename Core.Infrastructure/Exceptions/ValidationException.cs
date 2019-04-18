namespace Core.Infrastructure.Exceptions
{
    using System;

    [ErrorDescription("Bad Request", "Operation is not valid")]
    public class ValidationException : ErrorCodeException
    {
        public ValidationException() { }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
