using System;
using System.Collections.Generic;
using SamuraiDojo.Challenges;
using SamuraiDojo.SamuraiStats;

namespace SamuraiDojo.Stats
{
    public class ScoreKeeper
    {
        public readonly static Dictionary<string, Score> Score;
        public readonly static Type CurrentChallenge = typeof(ClockAngler);

        static ScoreKeeper()
        {
            Score = new Dictionary<string, Score>();
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

        public static void RegisterSensei(string sensei, Type type)
        {
            if (Score.ContainsKey(sensei))
                Score[sensei].SenseiCount++;
            else
                Score.Add(sensei, new Score
                {
                    SenseiCount = 1
                });
        }
    }
}
