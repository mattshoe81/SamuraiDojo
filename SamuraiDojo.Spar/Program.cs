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
            Console.WriteLine("Press any key to analyze rankings. ");
            Console.ReadKey();
            Console.WriteLine($"{Environment.NewLine}Loading...{Environment.NewLine}");

            new TestRunner().Run();

            foreach (KeyValuePair<string, Score> pair in Samurai.Score)
                Console.WriteLine($"{pair.Key}:\t{pair.Value.Wins}");

            Console.WriteLine($"{Environment.NewLine}Press any key to close.{Environment.NewLine}");
            Console.ReadKey();
        }
    }
}
