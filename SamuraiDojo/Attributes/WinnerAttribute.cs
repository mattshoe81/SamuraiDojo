using System;
using SamuraiDojo.SamuraiStats;

namespace SamuraiDojo.Attributes
{
    public class WinnerAttribute : Attribute
    {
        public string Name { get; set; }

        public WinnerAttribute(string winner)
        {
            Name = winner;
            Samurai.AddPoint(winner);
        }
    }
}
