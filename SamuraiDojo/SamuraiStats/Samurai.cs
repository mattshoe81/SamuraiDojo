using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.SamuraiStats
{
    public class Samurai
    {
        public const string MATT = "Matt Shoemaker";
        public const string DUSTIN = "Dustin Mattox";
        public const string JT = "Jon Turner";
        public const string JEFF = "Jeff Moore";
        public const string SANJOG = "Sanjog Jain";

        private readonly static Dictionary<string, SamuraiScore> Score;

        static Samurai()
        {
            Score = new Dictionary<string, SamuraiScore>();
        }

        public static void AddWin(string winner)
        {
            if (Score.ContainsKey(winner))
                 Score[winner].Wins++;
            else
                Score.Add(winner, new SamuraiScore
                {
                    Wins = 1
                });
        }

        public static void AddSensei(string sensei)
        {
            if (Score.ContainsKey(sensei))
                Score[sensei].SenseiCount++;
            else
                Score.Add(sensei, new SamuraiScore
                {
                    SenseiCount = 1
                });
        }
    }
}
