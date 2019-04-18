using System;
using System.Collections;
using Core.Infrastructure.Exceptions;

namespace Core.Infrastructure.Extensions
{
    public static class ExceptionExtensions
    {
        public static void ThrowIfNull<T>(this T target, string message)
        {
            if (target == null)
            {
                throw new ObjectNotFoundException(message);
            }
        }

        public static void ThrowNotFoundIf<T>(this T target, Func<T, bool> condition, string message)
        {
            if (target == null || condition(target))
            {
                var type = typeof(T);

                if (type.GetInterface(nameof(IEnumerable), true) != null)
                {
                    if (type.IsGenericType)
                        type = type.GetGenericArguments()[0];
                }

                throw new ObjectNotFoundException(message);
            }
        }

        public static void ThrowNoValidIf<T>(this T target, Func<T, bool> condition, string message)
        {
            if (condition(target))
            {
                throw new ValidationException(message);
            }
        }
    }
}
