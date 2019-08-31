using System;
using System.Collections.Generic;
using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;
using SamuraiDojo.Repositories;

namespace SamuraiDojo.Models
{
    /// <summary>
    /// The outcome of a battle for a specific player.
    /// </summary>
    public class PlayerBattleResult : IComparable<PlayerBattleResult>
    {
        public WrittenByAttribute Player { get; set; }

        public int Points { get; set; }

        public EfficiencyResult Efficiency { get; set; }

        public List<BonusPointsAttribute> Awards { get; set; }

        public PlayerBattleResult()
        {
            Awards = new List<BonusPointsAttribute>();
        }

        public int CompareTo(PlayerBattleResult other)
        {
            int comparison = other.Points - Points;
            if (comparison == 0)
            {
                Player thisPlayer = PlayerRepository.GetPlayer(Player.Name);
                Player otherPlayer = PlayerRepository.GetPlayer(other.Player.Name);

                if (thisPlayer.Rank < otherPlayer.Rank)
                    comparison = -1;
                else if (thisPlayer.Rank > otherPlayer.Rank)
                    comparison = 1;
                else
                    comparison = string.Compare(thisPlayer.Name, otherPlayer.Name);
            }

            return comparison;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            else if (object.ReferenceEquals(this, obj))
                return true;
            else if (obj is PlayerBattleResult)
                return Player.Name == ((PlayerBattleResult)obj).Player.Name;

            return false;
        }

        public override int GetHashCode()
        {
            return Player.GetHashCode();
        }

    }
}
