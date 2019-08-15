using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;

namespace SamuraiDojo.Models
{
    /// <summary>
    /// The outcome of a battle for a specific player.
    /// </summary>
    public class BattleResult : IComparable<BattleResult>
    {
        public WrittenByAttribute Player { get; set; }

        public int Points { get; set; }

        public EfficiencyResult Efficiency { get; set; }

        public int CompareTo(BattleResult other)
        {
            int comparison = other.Points - Points;
            return comparison;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            else if (object.ReferenceEquals(this, obj))
                return true;
            else if (obj is BattleResult)
                return Player.Name == ((BattleResult)obj).Player.Name;

            return false;
        }

        public override int GetHashCode()
        {
            return Player.GetHashCode();
        }

    }
}
