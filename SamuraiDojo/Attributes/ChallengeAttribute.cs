﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Attributes
{
    public class ChallengeAttribute : Attribute
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }

        private string deadlineString;

        public ChallengeAttribute(string date, string name)
        {
            Name = name;
            Deadline = ParseDate(date);
            //Description = LoadDescription();
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

        
    }
}
