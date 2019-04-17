using System;

namespace Core.Infrastructure.Helpers
{
    public static class Helper
    {
        public static string Format(DateTime dateTime) => dateTime.ToString("g");

    }
}
