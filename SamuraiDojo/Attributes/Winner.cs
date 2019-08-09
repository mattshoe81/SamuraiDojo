using System;
using SamuraiDojo.SamuraiStats;

namespace SamuraiDojo.Attributes
{
    public class Winner : Attribute
    {
        public string Name { get; set; }

        public Winner(string winner)
        {
            Name = winner;
            Samurai.AddWin(winner);
        }
    }
}
