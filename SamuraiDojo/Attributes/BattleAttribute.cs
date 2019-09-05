using System;
using System.Globalization;
using System.IO;
using SamuraiDojo.Interfaces;

namespace SamuraiDojo.Attributes
{
    public class BattleAttribute : Attribute, IBattleAttribute
    {
        public string Name { get; set; }

        public DateTime Deadline { get; set; }

        public ISenseiAttribute Sensei { get; set; }

        public Type Type { get; set; }


        private string deadlineString;

        public BattleAttribute() { }

        public BattleAttribute(string date, string name, Type type)
        {
            Name = name;
            Deadline = ParseDate(date);
            Type = type;
        }

        private DateTime ParseDate(string date)
        {
            string[] dateParts = date.Split('/');
            deadlineString = $"{dateParts[0].PadLeft(2, '0')}-{dateParts[1].PadLeft(2, '0')}-{FormatYearString(dateParts[2])}";
            DateTime deadline = DateTime.ParseExact(deadlineString, "MM-dd-yyyy", CultureInfo.InvariantCulture);

            return deadline;
        }

        private string FormatYearString(string year)
        {
            string result = year;
            if (year.Length != 4)
                result = $"20{year.Substring(year.Length - 2)}";

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            else if (object.ReferenceEquals(this, obj))
                return true;
            else if (obj is BattleAttribute)
                return Name == ((BattleAttribute)obj).Name;

            return false;
        }

        private string LoadDescription()
        {
            // TODO - this is broken. probably a better way
            string directory = Directory.GetCurrentDirectory();
            string path = Path.Combine(directory, "Descriptions", $"{deadlineString}.txt");
            string description = "DESCRIPTION NOT FOUND";
            if (File.Exists(path))
            {
                try
                {
                    description = File.ReadAllText(path);
                }
                catch (Exception ex) { }
            }

            return description;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

    }
}
