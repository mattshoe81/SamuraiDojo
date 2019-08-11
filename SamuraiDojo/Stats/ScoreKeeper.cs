using System;
using System.Collections.Generic;
using SamuraiDojo.Challenges.Week1;
using SamuraiDojo.Stats;

namespace SamuraiDojo.Stats
{
    public class ScoreKeeper 
    {
        public readonly static Dictionary<string, PlayerStats> Players;
        public readonly static List<Type> Challenges;
        public readonly static Type CurrentChallenge = typeof(ClockAngler);

        static ScoreKeeper()
        {
            Players = new Dictionary<string, PlayerStats>();
            Challenges = new List<Type>();
        }

        public static PlayerStats GetPlayer(string name)
        {
            PlayerStats player = null;
            if (name != null)
            {
                name = name.ToUpper();
                if (Players.ContainsKey(name))
                    player = Players[name];
            }

            return player;
        }

        public static void AddPoint(string samurai, Type challenge)
        {
            if (Players.ContainsKey(samurai))
            {
                Players[samurai].TotalPoints++;
                int challengePoints = Players[samurai].PointsByChallenge[challenge];
                Players[samurai].PointsByChallenge[challenge] = ++challengePoints;
            }
            else
            {
                Players.Add(samurai, new PlayerStats
                {
                    Name = samurai.ToUpper(),

                    TotalPoints = 1,
                    PointsByChallenge = new Dictionary<Type, int>
                    {
                        { challenge, 1 }
                    }
                });
            }
        }
    }
}
