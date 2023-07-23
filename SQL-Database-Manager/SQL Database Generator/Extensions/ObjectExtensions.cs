using System;

namespace SQL_Database_Generator.Extensions
{
    public static class ObjectExtensions
    {
        public static void ThrowIfNull<T>(this T value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }
    }
}   