using System;
using System.Collections.Generic;
using SamuraiDojo.IOC.Interfaces;

namespace SamuraiDojo.Models
{
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public int SenseiCount { get; set; }

        public int TotalPoints { get; set; }

        public Dictionary<Type, int> PointsByBattle { get; set; }

        public int BattlesCompleted => PointsByBattle == null ? 0 : PointsByBattle.Keys.Count;

        public int Rank { get; set; }

        /// <summary>
        /// This is essentially the ranking algorithm.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public int CompareTo(IPlayer player)
        {
            int result = 0;
            if (TotalPoints > player.TotalPoints)
                result = -1;
            else if (TotalPoints < player.TotalPoints)
                result = 1;
            else
            {
                if (BattlesCompleted > player.BattlesCompleted)
                    result = 1;
                else if (BattlesCompleted < player.BattlesCompleted)
                    result = -1;
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            else if (object.ReferenceEquals(this, obj))
                return true;
            else if (obj is Player)
                return Name == ((Player)obj).Name;

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
