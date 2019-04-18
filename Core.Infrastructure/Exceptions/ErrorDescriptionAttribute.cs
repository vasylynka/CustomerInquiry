using System;

namespace Core.Infrastructure.Exceptions
{
    public class ErrorDescriptionAttribute : Attribute
    {
        public string Type { get; }

        public string Message { get; }

        public ErrorDescriptionAttribute(string type, string message = null)
        {
            Message = message;
            Type = type;
        }
    }
}
