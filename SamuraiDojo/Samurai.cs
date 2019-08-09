using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Challenges;
using SamuraiDojo.SamuraiStats;

namespace SamuraiDojo
{
    public class Samurai
    {
        public const string MATT = "Matt Shoemaker";
        public const string DUSTIN = "Dustin Mattox";
        public const string JT = "Jon Turner";
        public const string JEFF = "Jeff Moore";
        public const string SANJOG = "Sanjog Jain";

        public readonly static Dictionary<string, Score> Score;
        public readonly static Type CurrentChallenge = typeof(ClockAngler);

        static Samurai()
        {
            Score = new Dictionary<string, Score>();
        }

        public static void AddPoint(string samurai, Type challenge)
        {
            if (Score.ContainsKey(samurai))
            {
                Score[samurai].AllTimeTotal++;
                int challengePoints = Score[samurai].PointsByChallenge[challenge];
                Score[samurai].PointsByChallenge[challenge] = ++challengePoints;
            }
            else
            {
                Score.Add(samurai, new Score
                {
                    AllTimeTotal = 1,
                    PointsByChallenge = new Dictionary<Type, int>
                    {
                        { challenge, 1 }
                    }
                });
            }
        }

        public static void AddSensei(string sensei)
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
