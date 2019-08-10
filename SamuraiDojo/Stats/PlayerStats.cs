using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Stats
{
    public class PlayerStats
    {
        public string Username { get; set; }

        public int SenseiCount { get; set; }

        public int TotalPoints { get; set; }

        public Dictionary<Type, int> PointsByChallenge { get; set; }

        public int ChallengesCompleted { get; set; }

        public int Rank { get; set; }
    }
}
