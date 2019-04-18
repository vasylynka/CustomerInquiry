using System;

namespace Core.Infrastructure.Exceptions
{
    [ErrorDescription("Not Found", "Object not found")]
    public class ObjectNotFoundException : ErrorCodeException
    {
        public ObjectNotFoundException() { }

        public ObjectNotFoundException(string message) : base(message) { }

        public ObjectNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
