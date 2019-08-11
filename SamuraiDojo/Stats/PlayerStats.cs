using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Stats
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public string Name { get; set; }

        public int SenseiCount { get; set; }

        public int TotalPoints { get; set; }

        public Dictionary<Type, int> PointsByChallenge { get; set; }

        public int ChallengesCompleted
        {
            get => PointsByChallenge == null ? 0 : PointsByChallenge.Keys.Count;
        }

        public int Rank { get; set; }

        public int CompareTo(PlayerStats player)
        {
            int result = 0;
            if (TotalPoints > player.TotalPoints)
                result = -1;
            else if (TotalPoints < player.TotalPoints)
                result = 1;
            else
            {
                if (ChallengesCompleted > player.ChallengesCompleted)
                    result = 1;
                else if (ChallengesCompleted < player.ChallengesCompleted)
                    result = -1;
            }

            return result;
        }
    }
}
