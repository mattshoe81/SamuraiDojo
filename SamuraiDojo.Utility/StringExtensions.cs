using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Utility
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string value, string other)
        {
            return value.ToUpper() == other.ToUpper();
        }

        public static string DefaultIfEmpty(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "--";
            else
                return value;
        }
    }
}
