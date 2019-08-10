using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiDojo.SamuraiStats;
using SamuraiDojo.Test;

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
                Samurai.AddPoint(context.WrittenBy, context.ClassUnderTest);
            };
            testRunner.Run();

            foreach (KeyValuePair<string, Score> pair in Samurai.Score)
                Console.WriteLine($"{pair.Key}:\t{pair.Value.AllTimeTotal}");

            Console.WriteLine($"{Environment.NewLine}Press any key to close.{Environment.NewLine}");
            Console.ReadKey();
        }
    }
}
