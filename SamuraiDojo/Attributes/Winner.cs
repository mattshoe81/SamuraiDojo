using System;
using SamuraiDojo.SamuraiStats;

namespace SamuraiDojo.Attributes
{
    public class Winner : Attribute
    {

        public Winner(string winner)
        {
            Samurai.AddWin(winner);
        }
    }
}
