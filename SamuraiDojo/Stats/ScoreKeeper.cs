using System;
using System.Collections.Generic;
using SamuraiDojo.Challenges.Week1;
using SamuraiDojo.SamuraiStats;

namespace SamuraiDojo.Stats
{
    public class ScoreKeeper
    {
        public readonly static Dictionary<string, Score> Score;
        public readonly static List<Type> Challenges;
        public readonly static Type CurrentChallenge = typeof(ClockAngler);

        static ScoreKeeper()
        {
            Score = new Dictionary<string, Score>();
            Challenges = new List<Type>();
        }

        public static void AddPoint(string samurai, Type challenge)
        {
            if (Score.ContainsKey(samurai))
            {
                Score[samurai].TotalPoints++;
                int challengePoints = Score[samurai].PointsByChallenge[challenge];
                Score[samurai].PointsByChallenge[challenge] = ++challengePoints;
            }
            else
            {
                Score.Add(samurai, new Score
                {
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
