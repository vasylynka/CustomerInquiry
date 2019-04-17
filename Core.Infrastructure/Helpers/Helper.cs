﻿using System;
using System.ComponentModel;
using System.Linq;

namespace Core.Infrastructure.Helpers
{
    public static class Helper
    {
        public static string Format(DateTime dateTime) => dateTime.ToString("dd/MM/yyyy hh:MM");

        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();

            var name = Enum.GetName(type, value);
            var dn = type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<DescriptionAttribute>()
                .SingleOrDefault();

            return dn?.Description;
        }
    }
}
