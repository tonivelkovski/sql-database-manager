using System;

namespace SQL_Database_Generator.Extensions
{
    public static class StringExtensions
    {
        public static void ThrowIfNullOrWhiteSpace(this string value, string paramName)
        {
            value.ThrowIfNull(paramName);

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(paramName);
            }
        }
    }
}
