using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.Attributes;
using SamuraiDojo.SamuraiStats;
using SamuraiDojo.Stats;
using SamuraiDojo.Test;
using SamuraiDojo.Utility;

namespace SamuraiDojo.Spar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Loading...{Environment.NewLine}");

            TestRunner testRunner = new TestRunner();
            testRunner.OnTestPass = (context) =>
            {
                ScoreKeeper.AddPoint(context.WrittenBy, context.ClassUnderTest);
                ChallengeAttribute challenge = AttributeUtility.GetAttribute<ChallengeAttribute>(context.ClassUnderTest);

            };
            testRunner.Run();

            foreach (KeyValuePair<string, Score> pair in ScoreKeeper.Score)
                Console.WriteLine($"{pair.Key}:\t{pair.Value.TotalPoints}");

            Console.WriteLine($"{Environment.NewLine}Press any key to close.{Environment.NewLine}");
            Console.ReadKey();
        }
    }
}
