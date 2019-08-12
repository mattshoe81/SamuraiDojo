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

        public static void AddPoint(string samurai, Type challenge, int points = 1)
        {
            if (samurai != null)
                samurai = samurai.ToUpper();

            if (Players.ContainsKey(samurai))
            {
                Players[samurai].TotalPoints += points;
                if (Players[samurai].PointsByChallenge.ContainsKey(challenge))
                {
                    int challengePoints = Players[samurai].PointsByChallenge[challenge];
                    Players[samurai].PointsByChallenge[challenge] = challengePoints + points;
                }
                else
                {
                    Players[samurai].PointsByChallenge.Add(challenge, points);
                }
            }
            else
            {
                Players.Add(samurai, new PlayerStats
                {
                    Name = samurai,
                    TotalPoints = points,
                    PointsByChallenge = new Dictionary<Type, int>
                    {
                        { challenge, points }
                    }
                });
            }
        }

        public static void AddPlayer(string samurai)
        {
            if (samurai != null)
                samurai = samurai.ToUpper();

            if (!Players.ContainsKey(samurai))
            {
                Players.Add(samurai, new PlayerStats
                {
                    Name = samurai,
                    TotalPoints = 0,
                    PointsByChallenge = new Dictionary<Type, int>()
                });
            }
        }
    }
}
