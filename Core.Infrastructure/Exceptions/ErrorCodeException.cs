using System;

namespace Core.Infrastructure.Exceptions
{
    public class ErrorCodeException : Exception
    {
        public ErrorCodeException() { }

        public ErrorCodeException(string message) : base(message) { }

        public ErrorCodeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
