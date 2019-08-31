using System;
using System.Collections.Generic;
using SamuraiDojo.Attributes;
using SamuraiDojo.Attributes.Bonus;
using SamuraiDojo.IoC;
using SamuraiDojo.IoC.Interfaces;
using SamuraiDojo.Repositories;

namespace SamuraiDojo.Models
{
    /// <summary>
    /// The outcome of a battle for a specific player.
    /// </summary>
    internal class PlayerBattleResult : IPlayerBattleResult
    {
        public IWrittenByAttribute Player { get; set; }

        public int Points { get; set; }

        public IEfficiencyResult Efficiency { get; set; }

        public List<IBonusPointsAttribute> Awards { get; set; }

        public PlayerBattleResult()
        {
            Awards = new List<IBonusPointsAttribute>();
        }

        public int CompareTo(IPlayerBattleResult other)
        {
            int comparison = other.Points - Points;
            if (comparison == 0)
            {
                IPlayer thisPlayer = Factory.Get<IPlayerRepository>().GetPlayer(Player.Name);
                IPlayer otherPlayer = Factory.Get<IPlayerRepository>().GetPlayer(other.Player.Name);

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
            else if (obj is IPlayerBattleResult)
                return Player.Name == ((IPlayerBattleResult)obj).Player.Name;

            return false;
        }

        public override int GetHashCode()
        {
            return Player.GetHashCode();
        }

    }
}
