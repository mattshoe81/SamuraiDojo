using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Utility
{
    public static class DateTimeExtensions
    {
        public static string ToVerboseDateTime(this DateTime date)
        {
            DateTime modified = date.AddHours(-4);
            string result = $"{modified.ToLongTimeString()} -- {modified.ToLongDateString()}";

            return result;
        }

        public static string ToSimpleDateString(this DateTime date)
        {
            string result = date.ToString("MM-dd-yyyy");
            return result;
        }
    }
}
