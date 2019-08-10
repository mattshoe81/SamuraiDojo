using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes
{
    public class ChallengeAttribute : Attribute
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }

        public ChallengeAttribute(string date, string name)
        {
            Name = name;
            Deadline = ParseDate(date);
        }

        private DateTime ParseDate(string date)
        {
            string[] dateParts = date.Split('/');
            string formatted = $"{dateParts[0].PadLeft(2, '0')}/{dateParts[1].PadLeft(2, '0')}/{FormatYearString(dateParts[2])}";
            DateTime deadline = DateTime.ParseExact(formatted, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            return deadline;
        }

        private string FormatYearString(string year)
        {
            string result = year;
            if (year.Length != 4)
                result = $"20{year.Substring(year.Length - 2)}";

            return result;

        }

        
    }
}
